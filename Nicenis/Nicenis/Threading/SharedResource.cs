/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.12.15
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Nicenis.Threading
{
    #region ISharedResourceUserInfo Related

    /// <summary>
    /// Provides shared resource user information.
    /// </summary>
    /// <typeparam name="TResource">The resource type.</typeparam>
    public interface ISharedResourceUserInfo<TResource>
    {
        /// <summary>
        /// The shared resource.
        /// </summary>
        TResource Resource { get; }

        /// <summary>
        /// The index in tasks that use the resource concurrently.
        /// </summary>
        int UserIndex { get; }
    }

    /// <summary>
    /// Provides shared resource user information.
    /// </summary>
    /// <typeparam name="TResource">The resource type.</typeparam>
    internal class SharedResourceUserInfo<TResource> : ISharedResourceUserInfo<TResource>
    {
        #region Consturctors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resource">The shared resource.</param>
        /// <param name="userIndex">The index in tasks that use the resource concurrently.</param>
        public SharedResourceUserInfo(TResource resource, int userIndex)
        {
            Resource = resource;
            UserIndex = userIndex;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// The shared resource.
        /// </summary>
        public TResource Resource { get; private set; }

        /// <summary>
        /// The index in tasks that use the resource concurrently.
        /// </summary>
        public int UserIndex { get; private set; }

        #endregion
    }

    #endregion

    /// <summary>
    /// Manages accessing a shared resource.
    /// </summary>
    /// <remarks>
    /// This class is thread-safe.
    /// If TResource implements IDisposable, it is disposed when SharedResource&lt;TResource&gt; is disposed.
    /// </remarks>
    /// <typeparam name="TResource">The shared resource type.</typeparam>
    public class SharedResource<TResource> : IDisposable
    {
        #region QueuedTask

        /// <summary>
        /// Represents a task that is queued.
        /// </summary>
        private class QueuedTask
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            public QueuedTask() { }

            #endregion


            #region Public Properties

            /// <summary>
            /// The task that runs codes.
            /// </summary>
            public Task Task { get; set; }

            /// <summary>
            /// The index in tasks that use the resource concurrently.
            /// </summary>
            public int UserIndex { get; set; }

            #endregion
        }

        #endregion


        #region Fields

        /// <summary>
        /// The resource.
        /// </summary>
        TResource _resource;

        /// <summary>
        /// Whether it is disposed.
        /// This field must be updated within a lock (_taskQueue) block.
        /// </summary>
        bool _isDisposed;

        /// <summary>
        /// The task queue.
        /// This field must be used within a lock (_taskQueue) block.
        /// </summary>
        Queue<QueuedTask> _taskQueue = new Queue<QueuedTask>();

        /// <summary>
        /// The running tasks.
        /// This field must be used within a lock (_taskQueue) block.
        /// </summary>
        Task[] _runningTasks = null;

        /// <summary>
        /// The max concurrent user count.
        /// This field must be updated within a lock (_taskQueue) block.
        /// </summary>
        int _maxConcurrentUserCount = 1;

        /// <summary>
        /// The current user count.
        /// This field must be updated within a lock (_taskQueue) block.
        /// </summary>
        int _userCount = 0;

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resource">The shared resource.</param>
        /// <param name="maxConcurrentUserCount">The max concurrent user count.</param>
        /// <param name="isMaxConcurrentUserCountReadOnly">Whether the MaxConcurrentUserCount property is read only.</param>
        public SharedResource(TResource resource, int maxConcurrentUserCount = 1, bool isMaxConcurrentUserCountReadOnly = true)
        {
            if (maxConcurrentUserCount <= 0)
                throw new ArgumentException("The maxConcurrentUserCount must be greater than zero.");

            _resource = resource;
            _maxConcurrentUserCount = maxConcurrentUserCount;
            IsMaxConcurrentUserCountReadOnly = isMaxConcurrentUserCountReadOnly;
        }

        #endregion


        #region Helpers

        /// <summary>
        /// Whether the task is ended.
        /// </summary>
        /// <param name="task">The task to check.</param>
        /// <returns>True if it is ended; otherwise false.</returns>
        private static bool IsEndedTask(Task task)
        {
            Debug.Assert(task != null);

            switch (task.Status)
            {
                case TaskStatus.Canceled:
                case TaskStatus.Faulted:
                case TaskStatus.RanToCompletion:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Initializes the running tasks array.
        /// This method must be called in a lock (_taskQueue) block.
        /// </summary>
        /// <returns>True if the running tasks array has empty slots or unknown; otherwise false if it has no empty slot.</returns>
        private bool InitializeRunningTasks()
        {
            // If the running tasks is not initialized..
            if (_runningTasks == null)
            {
                _runningTasks = new Task[_maxConcurrentUserCount];
                return true; // Empty slot available.
            }

            // If the max concurrent user count is not changed..
            if (_runningTasks.Length == _maxConcurrentUserCount)
                return true; // Empty slot unknown.

            // If the max concurrent user count is decreased...
            if (_maxConcurrentUserCount < _runningTasks.Length)
            {
                // Gets the task count.
                int runningTaskCount = _runningTasks.Count(p => p != null);

                // If there is no empty slot, it is not possible to shrink the running tasks array.
                if (runningTaskCount == _runningTasks.Length)
                    return false; // No empty slot available.

                // Shrinks the running tasks array.
                Task[] newRunningTasks = new Task[Math.Max(runningTaskCount, _maxConcurrentUserCount)];
                int index = 0;
                foreach (Task runningTask in _runningTasks)
                {
                    if (runningTask != null)
                        newRunningTasks[index++] = runningTask;
                }
                _runningTasks = newRunningTasks;

                // No empty slot if the task count equals to the running tasks array length.
                return runningTaskCount != _runningTasks.Length;
            }
            else
            {
                // Increases the running tasks array.
                Task[] newRunningTasks = new Task[_maxConcurrentUserCount];
                Array.Copy(_runningTasks, newRunningTasks, _runningTasks.Length);
                _runningTasks = newRunningTasks;

                return true; // Empty slot available.
            }
        }

        /// <summary>
        /// Removes ended tasks from the running tasks array.
        /// This method must be called in a lock (_taskQueue) block.
        /// </summary>
        /// <param name="endingTask">The task that is about to end.</param>
        private void RemoveEndedTasks(Task endingTask = null)
        {
            // If the running tasks array is not created..
            if (_runningTasks == null)
                return;

            // For each running task...
            for (int i = 0; i < _runningTasks.Length; i++)
            {
                // Gets a running task..
                Task runningTask = _runningTasks[i];
                if (runningTask == null)
                    continue;

                // Removes ended tasks.
                if (IsEndedTask(runningTask))
                {
                    _runningTasks[i] = null;
                    _userCount--;
                    continue;
                }

                // Removes the task that is about to end.
                if (endingTask != null && runningTask == endingTask)
                {
                    _runningTasks[i] = null;
                    _userCount--;
                    continue;
                }
            }
        }

        /// <summary>
        /// Starts queued tasks if it is appropriate.
        /// This method must be called in a lock (_taskQueue) block.
        /// </summary>
        private void StartQueuedTasks()
        {
            Debug.Assert(_maxConcurrentUserCount > 0);

            // If there is no task in the queue..
            if (_taskQueue.Count == 0)
                return;

            // Initialize the running tasks array.
            bool noEmptySlot = InitializeRunningTasks() == false;

            // If there is no empty slot..
            if (noEmptySlot)
                return;

            // Starts queued tasks.
            for (int i = 0; i < _runningTasks.Length; i++)
            {
                if (_runningTasks[i] != null)
                    continue;

                while (_taskQueue.Count > 0)
                {
                    // Gets a queued task and sets the user index.
                    QueuedTask queuedTask = _taskQueue.Dequeue();
                    queuedTask.UserIndex = i;

                    try
                    {
                        // Starts the queued task.
                        queuedTask.Task.Start();
                        _runningTasks[i] = queuedTask.Task;
                        _userCount++;
                    }
                    catch (Exception e)
                    {
                        // If it is canceled, skips it.
                        if (queuedTask.Task.IsCanceled)
                            continue;

                        throw new InvalidOperationException("There is a queued task that is already started.", e);
                    }

                    break;

                } // while (_taskQueue.Count > 0)

                if (_taskQueue.Count == 0)
                    break;

            } // for (int i = 0; i < _runningTasks.Length; i++)
        }

        #endregion


        #region Properties

        /// <summary>
        /// Whether the MaxConcurrentUserCount property is read only.
        /// </summary>
        public bool IsMaxConcurrentUserCountReadOnly { get; private set; }

        /// <summary>
        /// The number of max concurrent user that are allowed to use the resource concurrently.
        /// This propety must be greater than zero.
        /// </summary>
        public int MaxConcurrentUserCount
        {
            get { return _maxConcurrentUserCount; }
            set
            {
                if (IsMaxConcurrentUserCountReadOnly)
                    throw new ArgumentException("The MaxConcurrentUserCount is read-only.");

                if (value <= 0)
                    throw new ArgumentException("The MaxConcurrentUserCount must be greater than zero.");

                lock (_taskQueue)
                {
                    if (_maxConcurrentUserCount == value)
                        return;

                    _maxConcurrentUserCount = value;
                    RemoveEndedTasks();
                    StartQueuedTasks();
                }
            }
        }

        /// <summary>
        /// The number of user that uses the resource.
        /// </summary>
        public int UserCount
        {
            get { return _userCount; }
        }

        #endregion


        #region UseAsync Related

        /// <summary>
        /// Ensures that the shared resource is not disposed.
        /// </summary>
        private void EnsureNotDisposed()
        {
            if (_isDisposed)
                throw new InvalidOperationException("This shared resource is already disposed.");
        }

        /// <summary>
        /// Creates a queued task.
        /// </summary>
        /// <returns>An queued task instance.</returns>
        private QueuedTask CreateQueuedTask()
        {
            // Checks not disposed.
            EnsureNotDisposed();

            // Creates a QueuedTask.
            return new QueuedTask();
        }

        /// <summary>
        /// Enqueues a task and tries to start it.
        /// </summary>
        /// <param name="queuedTask">The queued task to enqueue.</param>
        /// <returns>The task of the queued task passed by parameter.</returns>
        private Task EnqueueTask(QueuedTask queuedTask)
        {
            Debug.Assert(queuedTask != null);

            // Starts the task.
            lock (_taskQueue)
            {
                // Checks not disposed.
                EnsureNotDisposed();

                _taskQueue.Enqueue(queuedTask);
                RemoveEndedTasks();
                StartQueuedTasks();
            }

            return queuedTask.Task;
        }

        /// <summary>
        /// Ends a task.
        /// </summary>
        /// <param name="endingQueuedTask">The queued task that is about to end.</param>
        private void EndTask(QueuedTask endingQueuedTask)
        {
            Debug.Assert(endingQueuedTask != null);

            // Removes the ending task.
            lock (_taskQueue)
            {
                RemoveEndedTasks(endingQueuedTask.Task);
                StartQueuedTasks();
            }
        }

        /// <summary>
        /// Creates a shared resource user info.
        /// </summary>
        /// <param name="queuedTask">The queued task.</param>
        /// <returns>The created instance.</returns>
        private ISharedResourceUserInfo<TResource> CreateUserInfo(QueuedTask queuedTask)
        {
            Debug.Assert(queuedTask != null);
            return new SharedResourceUserInfo<TResource>(_resource, queuedTask.UserIndex);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <param name="state">An object representing data to be used by the action.</param>
        /// <param name="cancellationToken">The CancellationToken that that the new task will observe.</param>
        /// <param name="creationOptions">The TaskCreationOptions used to customize the task’s behavior.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<ISharedResourceUserInfo<TResource>, object> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task(s => { try { action(CreateUserInfo(queuedTask), s); } finally { EndTask(queuedTask); } }, state, cancellationToken, creationOptions);

            // Enqueues the task.
            return EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <param name="state">An object representing data to be used by the action.</param>
        /// <param name="creationOptions">The TaskCreationOptions used to customize the task’s behavior.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<ISharedResourceUserInfo<TResource>, object> action, object state, TaskCreationOptions creationOptions)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task(s => { try { action(CreateUserInfo(queuedTask), s); } finally { EndTask(queuedTask); } }, state, creationOptions);

            // Enqueues the task.
            return EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <param name="state">An object representing data to be used by the action.</param>
        /// <param name="cancellationToken">The CancellationToken that that the new task will observe.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<ISharedResourceUserInfo<TResource>, object> action, object state, CancellationToken cancellationToken)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task(s => { try { action(CreateUserInfo(queuedTask), s); } finally { EndTask(queuedTask); } }, state, cancellationToken);

            // Enqueues the task.
            return EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <param name="state">An object representing data to be used by the action.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<ISharedResourceUserInfo<TResource>, object> action, object state)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task(s => { try { action(CreateUserInfo(queuedTask), s); } finally { EndTask(queuedTask); } }, state);

            // Enqueues the task.
            return EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <param name="cancellationToken">The CancellationToken that that the new task will observe.</param>
        /// <param name="creationOptions">The TaskCreationOptions used to customize the task’s behavior.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<ISharedResourceUserInfo<TResource>> action, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task(() => { try { action(CreateUserInfo(queuedTask)); } finally { EndTask(queuedTask); } }, cancellationToken, creationOptions);

            // Enqueues the task.
            return EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <param name="creationOptions">The TaskCreationOptions used to customize the task’s behavior.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<ISharedResourceUserInfo<TResource>> action, TaskCreationOptions creationOptions)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task(() => { try { action(CreateUserInfo(queuedTask)); } finally { EndTask(queuedTask); } }, creationOptions);

            // Enqueues the task.
            return EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <param name="cancellationToken">The CancellationToken that that the new task will observe.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<ISharedResourceUserInfo<TResource>> action, CancellationToken cancellationToken)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task(() => { try { action(CreateUserInfo(queuedTask)); } finally { EndTask(queuedTask); } }, cancellationToken);

            // Enqueues the task.
            return EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<ISharedResourceUserInfo<TResource>> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task(() => { try { action(CreateUserInfo(queuedTask)); } finally { EndTask(queuedTask); } });

            // Enqueues the task.
            return EnqueueTask(queuedTask);
        }


        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <typeparam name="T">The return data type.</typeparam>
        /// <param name="func">The delegate that represents the code to execute with the resource.</param>
        /// <param name="state">An object representing data to be used by the action.</param>
        /// <param name="cancellationToken">The CancellationToken that that the new task will observe.</param>
        /// <param name="creationOptions">The TaskCreationOptions used to customize the task’s behavior.</param>
        /// <returns>The task instance.</returns>
        public Task<T> UseAsync<T>(Func<ISharedResourceUserInfo<TResource>, object, T> func, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task<T>(s => { try { return func(CreateUserInfo(queuedTask), s); } finally { EndTask(queuedTask); } }, state, cancellationToken, creationOptions);

            // Enqueues the task.
            return (Task<T>)EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <typeparam name="T">The return data type.</typeparam>
        /// <param name="func">The delegate that represents the code to execute with the resource.</param>
        /// <param name="state">An object representing data to be used by the action.</param>
        /// <param name="creationOptions">The TaskCreationOptions used to customize the task’s behavior.</param>
        /// <returns>The task instance.</returns>
        public Task<T> UseAsync<T>(Func<ISharedResourceUserInfo<TResource>, object, T> func, object state, TaskCreationOptions creationOptions)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task<T>(s => { try { return func(CreateUserInfo(queuedTask), s); } finally { EndTask(queuedTask); } }, state, creationOptions);

            // Enqueues the task.
            return (Task<T>)EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <typeparam name="T">The return data type.</typeparam>
        /// <param name="func">The delegate that represents the code to execute with the resource.</param>
        /// <param name="state">An object representing data to be used by the action.</param>
        /// <param name="cancellationToken">The CancellationToken that that the new task will observe.</param>
        /// <returns>The task instance.</returns>
        public Task<T> UseAsync<T>(Func<ISharedResourceUserInfo<TResource>, object, T> func, object state, CancellationToken cancellationToken)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task<T>(s => { try { return func(CreateUserInfo(queuedTask), s); } finally { EndTask(queuedTask); } }, state, cancellationToken);

            // Enqueues the task.
            return (Task<T>)EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <typeparam name="T">The return data type.</typeparam>
        /// <param name="func">The delegate that represents the code to execute with the resource.</param>
        /// <param name="state">An object representing data to be used by the action.</param>
        /// <returns>The task instance.</returns>
        public Task<T> UseAsync<T>(Func<ISharedResourceUserInfo<TResource>, object, T> func, object state)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task<T>(s => { try { return func(CreateUserInfo(queuedTask), s); } finally { EndTask(queuedTask); } }, state);

            // Enqueues the task.
            return (Task<T>)EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <typeparam name="T">The return data type.</typeparam>
        /// <param name="func">The delegate that represents the code to execute with the resource.</param>
        /// <param name="cancellationToken">The CancellationToken that that the new task will observe.</param>
        /// <param name="creationOptions">The TaskCreationOptions used to customize the task’s behavior.</param>
        /// <returns>The task instance.</returns>
        public Task<T> UseAsync<T>(Func<ISharedResourceUserInfo<TResource>, T> func, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task<T>(() => { try { return func(CreateUserInfo(queuedTask)); } finally { EndTask(queuedTask); } }, cancellationToken, creationOptions);

            // Enqueues the task.
            return (Task<T>)EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <typeparam name="T">The return data type.</typeparam>
        /// <param name="func">The delegate that represents the code to execute with the resource.</param>
        /// <param name="creationOptions">The TaskCreationOptions used to customize the task’s behavior.</param>
        /// <returns>The task instance.</returns>
        public Task<T> UseAsync<T>(Func<ISharedResourceUserInfo<TResource>, T> func, TaskCreationOptions creationOptions)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task<T>(() => { try { return func(CreateUserInfo(queuedTask)); } finally { EndTask(queuedTask); } }, creationOptions);

            // Enqueues the task.
            return (Task<T>)EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <typeparam name="T">The return data type.</typeparam>
        /// <param name="func">The delegate that represents the code to execute with the resource.</param>
        /// <param name="cancellationToken">The CancellationToken that that the new task will observe.</param>
        /// <returns>The task instance.</returns>
        public Task<T> UseAsync<T>(Func<ISharedResourceUserInfo<TResource>, T> func, CancellationToken cancellationToken)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task<T>(() => { try { return func(CreateUserInfo(queuedTask)); } finally { EndTask(queuedTask); } }, cancellationToken);

            // Enqueues the task.
            return (Task<T>)EnqueueTask(queuedTask);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <typeparam name="T">The return data type.</typeparam>
        /// <param name="func">The delegate that represents the code to execute with the resource.</param>
        /// <returns>The task instance.</returns>
        public Task<T> UseAsync<T>(Func<ISharedResourceUserInfo<TResource>, T> func)
        {
            if (func == null)
                throw new ArgumentNullException("func");

            // Creates a task.
            QueuedTask queuedTask = CreateQueuedTask();
            queuedTask.Task = new Task<T>(() => { try { return func(CreateUserInfo(queuedTask)); } finally { EndTask(queuedTask); } });

            // Enqueues the task.
            return (Task<T>)EnqueueTask(queuedTask);
        }

        #endregion


        #region IDisposable Implementation

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // If it is already disposed..
            if (_isDisposed)
                return;

            IDisposable disposableResource = null;
            List<Task> tasksToWait = null;

            lock (_taskQueue)
            {
                // If it is already disposed..
                if (_isDisposed)
                    return;

                // Marks that it is disposed.
                _isDisposed = true;

                // Gets the IDisposable interface.
                disposableResource = _resource as IDisposable;
                if (disposableResource == null)
                    return;

                // Collects tasks to wait.
                foreach (QueuedTask queuedTask in _taskQueue)
                {
                    if (IsEndedTask(queuedTask.Task) == false)
                        (tasksToWait ?? (tasksToWait = new List<Task>())).Add(queuedTask.Task);
                }

                if (_runningTasks != null)
                {
                    foreach (Task task in _runningTasks)
                    {
                        if (task != null && IsEndedTask(task) == false)
                            (tasksToWait ?? (tasksToWait = new List<Task>())).Add(task);
                    }
                }

            } // lock (_taskQueue)

            // If there is no task to wait, disposes the resource.
            if (tasksToWait == null)
            {
                disposableResource.Dispose();
                return;
            }

            Task.Factory.StartNew(() =>
            {
                // Waits running and queued tasks.
                try { Task.WaitAll(tasksToWait.ToArray()); }
                catch { }

                // Disposes the resource.
                disposableResource.Dispose();
            });
        }

        #endregion
    }
}
