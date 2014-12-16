/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.12.15
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
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
    /// <summary>
    /// Manages accessing a shared resource.
    /// </summary>
    /// <remarks>
    /// This class is thread-safe.
    /// </remarks>
    /// <typeparam name="TResource">The shared resource type.</typeparam>
    public class SharedResource<TResource>
    {
        #region Fields

        /// <summary>
        /// The resource.
        /// </summary>
        TResource _resource;

        /// <summary>
        /// The task queue.
        /// This field must be used within a lock (_taskQueue) block.
        /// </summary>
        Queue<Task> _taskQueue = new Queue<Task>();

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
                switch (runningTask.Status)
                {
                    case TaskStatus.Canceled:
                    case TaskStatus.Faulted:
                    case TaskStatus.RanToCompletion:
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
                    // Gets a queued task.
                    Task task = _taskQueue.Dequeue();
                    try
                    {
                        // Starts the queued task.
                        task.Start();
                        _runningTasks[i] = task;
                        _userCount++;
                    }
                    catch (Exception e)
                    {
                        // If it is canceled, skips it.
                        if (task.IsCanceled)
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
        /// Enqueues the task and tries to start it.
        /// </summary>
        /// <param name="task">The task to enqueue.</param>
        /// <returns>The task passed by the parameter.</returns>
        private Task EnqueueTask(Task task)
        {
            Debug.Assert(task != null);

            // Starts the task.
            lock (_taskQueue)
            {
                _taskQueue.Enqueue(task);
                RemoveEndedTasks();
                StartQueuedTasks();
            }

            return task;
        }

        /// <summary>
        /// Ends the task.
        /// </summary>
        /// <param name="endingTask">The task that is about to end.</param>
        private void EndTask(Task endingTask)
        {
            Debug.Assert(endingTask != null);

            // Removes the ending task.
            lock (_taskQueue)
            {
                RemoveEndedTasks(endingTask);
                StartQueuedTasks();
            }
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <param name="state">An object representing data to be used by the action.</param>
        /// <param name="cancellationToken">The CancellationToken() that that the new task will observe.</param>
        /// <param name="creationOptions">The TaskCreationOptions used to customize the task’s behavior.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<object, TResource> action, object state, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            Task task = null;
            task = new Task(s => { try { action(s, _resource); } finally { EndTask(task); } }, state, cancellationToken, creationOptions);

            // Enqueues the task.
            return EnqueueTask(task);
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
        public Task UseAsync(Action<object, TResource> action, object state, TaskCreationOptions creationOptions)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            Task task = null;
            task = new Task(s => { try { action(s, _resource); } finally { EndTask(task); } }, state, creationOptions);

            // Enqueues the task.
            return EnqueueTask(task);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <param name="state">An object representing data to be used by the action.</param>
        /// <param name="cancellationToken">The CancellationToken() that that the new task will observe.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<object, TResource> action, object state, CancellationToken cancellationToken)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            Task task = null;
            task = new Task(s => { try { action(s, _resource); } finally { EndTask(task); } }, state, cancellationToken);

            // Enqueues the task.
            return EnqueueTask(task);
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
        public Task UseAsync(Action<object, TResource> action, object state)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            Task task = null;
            task = new Task(s => { try { action(s, _resource); } finally { EndTask(task); } }, state);

            // Enqueues the task.
            return EnqueueTask(task);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <param name="cancellationToken">The CancellationToken() that that the new task will observe.</param>
        /// <param name="creationOptions">The TaskCreationOptions used to customize the task’s behavior.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<TResource> action, CancellationToken cancellationToken, TaskCreationOptions creationOptions)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            Task task = null;
            task = new Task(() => { try { action(_resource); } finally { EndTask(task); } }, cancellationToken, creationOptions);

            // Enqueues the task.
            return EnqueueTask(task);
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
        public Task UseAsync(Action<TResource> action, TaskCreationOptions creationOptions)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            Task task = null;
            task = new Task(() => { try { action(_resource); } finally { EndTask(task); } }, creationOptions);

            // Enqueues the task.
            return EnqueueTask(task);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <param name="cancellationToken">The CancellationToken() that that the new task will observe.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<TResource> action, CancellationToken cancellationToken)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            Task task = null;
            task = new Task(() => { try { action(_resource); } finally { EndTask(task); } }, cancellationToken);

            // Enqueues the task.
            return EnqueueTask(task);
        }

        /// <summary>
        /// Uses the resource asynchronously.
        /// </summary>
        /// <remarks>
        /// The returned task must not be started by user code.
        /// </remarks>
        /// <param name="action">The delegate that represents the code to execute with the resource.</param>
        /// <returns>The task instance.</returns>
        public Task UseAsync(Action<TResource> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Creates a task.
            Task task = null;
            task = new Task(() => { try { action(_resource); } finally { EndTask(task); } });

            // Enqueues the task.
            return EnqueueTask(task);
        }

        #endregion
    }
}
