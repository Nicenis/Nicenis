/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.04.20
 * Version  $Id$
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchableObjectPerformanceTest
{
    class Program
    {
        class TestItem
        {
            Func<ITestable> _createTestable;

            public TestItem(Func<ITestable> createTestable)
            {
                Debug.Assert(createTestable != null);
                _createTestable = createTestable;
            }

            public ITestable Testable { get; private set; }
            public long TotalTicks { get; set; }

            public  void Reset()
            {
                Testable = _createTestable();
                TotalTicks = 0;
            }
        }

        static void Main(string[] args)
        {
            int[] iterationCounts =
            {
                1,
                1,
                10000,
            };

            TestItem[] testItems = new TestItem[]
            {
                new TestItem(() => new SampleL6()),
                new TestItem(() => new SampleLE6()),
                new TestItem(() => new SampleA6()),
                new TestItem(() => new SampleAE6()),

                new TestItem(() => new SampleL12()),
                new TestItem(() => new SampleLE12()),
                new TestItem(() => new SampleA12()),
                new TestItem(() => new SampleAE12()),

                new TestItem(() => new SampleL25()),
                new TestItem(() => new SampleLE25()),
                new TestItem(() => new SampleA25()),
                new TestItem(() => new SampleAE25()),

                new TestItem(() => new SampleL50()),
                new TestItem(() => new SampleLE50()),
                new TestItem(() => new SampleA50()),
                new TestItem(() => new SampleAE50()),

                new TestItem(() => new SampleL100()),
                new TestItem(() => new SampleLE100()),
                new TestItem(() => new SampleA100()),
                new TestItem(() => new SampleAE100()),
            };


            Console.WriteLine("Running performance test... Please wait.");

            foreach (int iterationCount in iterationCounts)
            {
                // Resets the test items.
                foreach (TestItem testItem in testItems)
                    testItem.Reset();

                // Runs the performance test.
                Stopwatch stopwatch = new Stopwatch();
                for (int i = 0; i < iterationCount; i++)
                {
                    foreach (TestItem testItem in testItems)
                    {
                        stopwatch.Restart();
                        testItem.Testable.RunTest(i);
                        stopwatch.Stop();

                        testItem.TotalTicks += stopwatch.ElapsedTicks;
                    }
                }

                // Outputs the performance test result.
                int currentPropertyCount = -1;
                foreach (TestItem testItem in testItems)
                {
                    string typeName = testItem.Testable.GetType().Name;
                    int propertyCount = int.Parse(new string(typeName.SkipWhile(p => char.IsNumber(p) == false).ToArray()));

                    if (currentPropertyCount != propertyCount)
                    {
                        Console.WriteLine();
                        currentPropertyCount = propertyCount;
                        Console.Write("[{0}I {1}P] ", iterationCount, propertyCount);
                    }

                    Console.Write(new string(typeName.Skip("Sample".Length).TakeWhile(p => char.IsNumber(p) == false).ToArray()) + ": ");
                    Console.Write((iterationCount == 1 ? testItem.TotalTicks : (testItem.TotalTicks / iterationCount)));
                    Console.Write("  ");
                }

                Console.WriteLine();

            } // foreach (int iterationCount in iterationCounts)


            // Outputs the Frequency.
            Console.WriteLine();
            Console.WriteLine(string.Format("Frequency in ticks per second: {0:N0}", Stopwatch.Frequency));
            Console.WriteLine();
        }
    }
}
