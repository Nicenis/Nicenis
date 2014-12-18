/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.12.17
 * Version  $Id$
 *
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicenis.Threading;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NicenisTests.Threading
{
    [TestClass]
    public class SharedResourceTests
    {
        #region Helpers

        public class TestResource
        {
            int _counter = 0;

            public int Counter { get { return _counter; } }

            public int IncreaseCounter()
            {
                return Interlocked.Increment(ref _counter);
            }

            public int DecreaseCounter()
            {
                return Interlocked.Decrement(ref _counter);
            }
        }

        public static void SpinRandomly()
        {
            DateTime startTime = DateTime.Now;
            long counter = startTime.Ticks % 10000;
            for (long i = 0; i < counter; i++)
            {
                TimeSpan span = DateTime.Now - startTime;
                double number = span.TotalMilliseconds * span.Ticks;
            }
        }

        #endregion


        [TestMethod]
        public void MaxConcurrentUserCount_Can_Not_Be_Set_When_IsMaxConcurrentUserCountReadOnly_Is_True()
        {
            // arrange
            const string testResource = "Test";
            SharedResource<string> sharedResource = new SharedResource<string>
            (
                resource: testResource,
                maxConcurrentUserCount: 1,
                isMaxConcurrentUserCountReadOnly: true
            );

            // act
            Exception cachedException = null;
            try { sharedResource.MaxConcurrentUserCount = 2; }
            catch (Exception e) { cachedException = e; }

            // assert
            Assert.IsNotNull(cachedException);
            Assert.IsTrue(cachedException.Message == "The MaxConcurrentUserCount is read-only.");
        }

        [TestMethod]
        public void MaxConcurrentUserCount_Can_Be_Set_When_IsMaxConcurrentUserCountReadOnly_Is_False()
        {
            // arrange
            const string testResource = "Test";
            SharedResource<string> sharedResource = new SharedResource<string>
            (
                resource: testResource,
                maxConcurrentUserCount: 1,
                isMaxConcurrentUserCountReadOnly: false
            );

            // act
            Exception cachedException = null;
            try { sharedResource.MaxConcurrentUserCount = 2; }
            catch (Exception e) { cachedException = e; }

            // assert
            Assert.IsNull(cachedException);
        }

        [TestMethod]
        public void MaxConcurrentUserCount_Constructor_Parameter_Can_Not_Be_Set_To_Number_Less_Or_Equal_To_Zero()
        {
            // arrange
            const string testResource = "Test";

            // act
            Exception cachedException = null;
            try
            {
                SharedResource<string> sharedResource = new SharedResource<string>
                (
                    resource: testResource,
                    maxConcurrentUserCount: 0,
                    isMaxConcurrentUserCountReadOnly: false
                );
            }
            catch (Exception e) { cachedException = e; }

            // assert
            Assert.IsNotNull(cachedException);
            Assert.IsTrue(cachedException.Message == "The maxConcurrentUserCount must be greater than zero.");
        }

        [TestMethod]
        public void MaxConcurrentUserCount_Can_Not_Be_Set_To_Number_Less_Or_Equal_To_Zero()
        {
            // arrange
            const string testResource = "Test";
            SharedResource<string> sharedResource = new SharedResource<string>
            (
                resource: testResource,
                maxConcurrentUserCount: 1,
                isMaxConcurrentUserCountReadOnly: false
            );

            // act
            Exception cachedException = null;
            try { sharedResource.MaxConcurrentUserCount = 0; }
            catch (Exception e) { cachedException = e; }

            // assert
            Assert.IsNotNull(cachedException);
            Assert.IsTrue(cachedException.Message == "The MaxConcurrentUserCount must be greater than zero.");
        }

        [TestMethod]
        public void One_MaxConcurrentUserCount_Allows_One_Action_Concurrently()
        {
            // arrange
            TestResource testResource = new TestResource();
            SharedResource<TestResource> sharedResource = new SharedResource<TestResource>
            (
                resource: testResource,
                maxConcurrentUserCount: 1,
                isMaxConcurrentUserCountReadOnly: true
            );

            const int actionCount = 100;
            Task[] tasks = new Task[actionCount];
            int[] startCounters = new int[actionCount];
            int[] endCounters = new int[actionCount];

            // act
            for (int i = 0; i < actionCount; i++)
            {
                int index = i;
                tasks[index] = sharedResource.UseAsync(info =>
                {
                    startCounters[index] = info.Resource.IncreaseCounter();
                    SpinRandomly();
                    endCounters[index] = info.Resource.DecreaseCounter();
                });
            }

            Task.WaitAll(tasks);

            // assert
            Assert.IsTrue(testResource.Counter == 0);
            Assert.IsTrue(startCounters.All(p => p == 1));
            Assert.IsTrue(endCounters.All(p => p == 0));
        }

        [TestMethod]
        public void One_MaxConcurrentUserCount_Allows_One_Func_Concurrently()
        {
            // arrange
            TestResource testResource = new TestResource();
            SharedResource<TestResource> sharedResource = new SharedResource<TestResource>
            (
                resource: testResource,
                maxConcurrentUserCount: 1,
                isMaxConcurrentUserCountReadOnly: true
            );

            const int actionCount = 100;
            Task<int>[] tasks = new Task<int>[actionCount];
            int[] startCounters = new int[actionCount];
            int[] endCounters = new int[actionCount];

            // act
            for (int i = 0; i < actionCount; i++)
            {
                int index = i;
                tasks[index] = sharedResource.UseAsync(info =>
                {
                    startCounters[index] = info.Resource.IncreaseCounter();
                    SpinRandomly();
                    endCounters[index] = info.Resource.DecreaseCounter();
                    return index;
                });
            }

            Task.WaitAll(tasks);

            // assert
            Assert.IsTrue(testResource.Counter == 0);
            Assert.IsTrue(startCounters.All(p => p == 1));
            Assert.IsTrue(endCounters.All(p => p == 0));

            for (int i = 0; i < actionCount; i++)
                Assert.IsTrue(tasks[i].Result == i);
        }

        [TestMethod]
        public void Three_MaxConcurrentUserCount_Allows_Three_Actions_Concurrently()
        {
            // arrange
            TestResource testResource = new TestResource();
            SharedResource<TestResource> sharedResource = new SharedResource<TestResource>
            (
                resource: testResource,
                maxConcurrentUserCount: 3,
                isMaxConcurrentUserCountReadOnly: true
            );

            const int actionCount = 100;
            Task[] tasks = new Task[actionCount];
            int[] startCounters = new int[actionCount];
            int[] endCounters = new int[actionCount];

            // act
            for (int i = 0; i < actionCount; i++)
            {
                int index = i;
                tasks[index] = sharedResource.UseAsync(info =>
                {
                    startCounters[index] = info.Resource.IncreaseCounter();
                    SpinRandomly();
                    endCounters[index] = info.Resource.DecreaseCounter();
                });
            }

            Task.WaitAll(tasks);

            // assert
            Assert.IsTrue(testResource.Counter == 0);
            Assert.IsTrue(startCounters.All(p => p >= 1 && p <= 3));
            Assert.IsTrue(endCounters.All(p => p >= 0 && p <= 2));
        }

        [TestMethod]
        public void One_To_Seven_MaxConcurrentUserCount_Allows_One_To_Seven_Actions_Concurrently()
        {
            // arrange
            TestResource testResource = new TestResource();
            SharedResource<TestResource> sharedResource = new SharedResource<TestResource>
            (
                resource: testResource,
                maxConcurrentUserCount: 1,
                isMaxConcurrentUserCountReadOnly: false
            );

            const int maxMaxConcurrentUserCount = 7;
            const int repeatCount = 2;
            const int segmentCount = 1000;
            const int actionCount = maxMaxConcurrentUserCount * repeatCount * segmentCount;
            Task[] tasks = new Task[actionCount];
            int[] userIndexes = new int[actionCount];
            int[] startCounters = new int[actionCount];
            int[] endCounters = new int[actionCount];
            int[] userCounts = new int[actionCount];

            // act
            int actionIndex = 0;
            for (int repeatIndex = 0; repeatIndex < repeatCount; repeatIndex++)
            {
                for (int concurrentUserCountIndex = 0; concurrentUserCountIndex < maxMaxConcurrentUserCount; concurrentUserCountIndex++)
                {
                    sharedResource.MaxConcurrentUserCount = repeatIndex % 2 == 0
                                                          ? concurrentUserCountIndex + 1
                                                          : maxMaxConcurrentUserCount - concurrentUserCountIndex;

                    for (int i = 0; i < segmentCount; i++)
                    {
                        int index = actionIndex++;
                        tasks[index] = sharedResource.UseAsync(info =>
                        {
                            userIndexes[index] = info.UserIndex;
                            startCounters[index] = info.Resource.IncreaseCounter();
                            SpinRandomly();
                            endCounters[index] = info.Resource.DecreaseCounter();
                        },
                        TaskCreationOptions.LongRunning);
                        userCounts[index] = sharedResource.UserCount;
                    }

                    Task[] segmentTasks = tasks.Skip(actionIndex - segmentCount).Take(segmentCount).ToArray();
                    Task.WaitAll(segmentTasks);
                }
            }

            // assert
            actionIndex = 0;
            Assert.IsTrue(testResource.Counter == 0);
            Assert.IsTrue(userIndexes.All(p => p >= 0 && p < maxMaxConcurrentUserCount));
            for (int repeatIndex = 0; repeatIndex < repeatCount; repeatIndex++)
            {
                for (int concurrentUserCountIndex = 0; concurrentUserCountIndex < maxMaxConcurrentUserCount; concurrentUserCountIndex++)
                {
                    int maxConcurrentUserCount = repeatIndex % 2 == 0
                                               ? concurrentUserCountIndex + 1
                                               : maxMaxConcurrentUserCount - concurrentUserCountIndex;
                    actionIndex += segmentCount;

                    int[] segmentStartCounters = startCounters.Skip(actionIndex - segmentCount).Take(segmentCount).ToArray();
                    int[] segmentEndCounters = endCounters.Skip(actionIndex - segmentCount).Take(segmentCount).ToArray();
                    int[] segmentUserCounts = userCounts.Skip(actionIndex - segmentCount).Take(segmentCount).ToArray();
                    Assert.IsTrue(segmentStartCounters.All(p => p >= 1 && p <= maxConcurrentUserCount));
                    Assert.IsTrue(segmentEndCounters.All(p => p >= 0 && p <= maxConcurrentUserCount - 1));
                    Assert.IsTrue(segmentUserCounts.All(p => p >= 1 && p <= maxMaxConcurrentUserCount));
                }
            }
        }

        [TestMethod]
        public void Next_Action_Runs_If_Previous_Action_Throws_Exception()
        {
            // arrange
            const string testResource = "Test";
            const string exceptionMessage = "Test Exception";
            SharedResource<string> sharedResource = new SharedResource<string>
            (
                resource: testResource,
                maxConcurrentUserCount: 1,
                isMaxConcurrentUserCountReadOnly: true
            );

            // act
            Task thrownTask = sharedResource.UseAsync(info =>
            {
                SpinRandomly();
                throw new InvalidOperationException(exceptionMessage);
            });

            string readTestResource = null;
            Task normalTask = sharedResource.UseAsync(info =>
            {
                SpinRandomly();
                readTestResource = testResource;
            });

            Exception cachedException = null;
            try { thrownTask.Wait(); }
            catch (Exception e) { cachedException = e; }

            normalTask.Wait();

            // assert
            Assert.IsNotNull(cachedException);
            Assert.IsTrue(cachedException is AggregateException);
            Assert.IsTrue(((AggregateException)cachedException).InnerExceptions.Count == 1);
            Assert.IsTrue(((AggregateException)cachedException).InnerExceptions.First().Message == exceptionMessage);
            Assert.IsTrue(readTestResource == testResource);
        }

        [TestMethod]
        public void Canceled_Action_Is_Skipped()
        {
            // arrange
            const string testResource = "Test";
            SharedResource<string> sharedResource = new SharedResource<string>
            (
                resource: testResource,
                maxConcurrentUserCount: 1,
                isMaxConcurrentUserCountReadOnly: true
            );
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Cancel();

            // act
            bool isCanceledTaskRun = false;
            Task canceledTask = sharedResource.UseAsync(info =>
            {
                SpinRandomly();
                isCanceledTaskRun = true;
            }, cancellationTokenSource.Token);

            string readTestResource = null;
            Task normalTask = sharedResource.UseAsync(info =>
            {
                SpinRandomly();
                readTestResource = testResource;
            });

            Exception cachedException = null;
            try { canceledTask.Wait(); }
            catch (Exception e) { cachedException = e; }

            normalTask.Wait();

            // assert
            Assert.IsFalse(isCanceledTaskRun);
            Assert.IsTrue(cachedException is AggregateException);
            Assert.IsTrue(((AggregateException)cachedException).InnerExceptions.Count == 1);
            Assert.IsTrue(((AggregateException)cachedException).InnerExceptions.First() is OperationCanceledException);
            Assert.IsTrue(readTestResource == testResource);
        }
    }
}
