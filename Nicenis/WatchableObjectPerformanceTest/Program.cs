/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.04.20
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

namespace PropertyObservablePerformanceTest
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

            public void CreateTestable()
            {
                Testable = _createTestable();
            }

            public void Reset()
            {
                TotalTicks = 0;
            }
        }

        static void Main(string[] args)
        {
            TestItem[] testItems = new TestItem[]
            {
                new TestItem(() => new SampleL6()),
                new TestItem(() => new SampleA6()),

                new TestItem(() => new SampleL12()),
                new TestItem(() => new SampleA12()),

                new TestItem(() => new SampleL25()),
                new TestItem(() => new SampleA25()),

                new TestItem(() => new SampleL50()),
                new TestItem(() => new SampleA50()),

                new TestItem(() => new SampleL100()),
                new TestItem(() => new SampleA100()),
            };

            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Running performance test... Please wait.");

            foreach (int accessCount in (new int[] { 1, 2, 4 }))
            {
                // Resets the test items.
                foreach (TestItem testItem in testItems)
                    testItem.Reset();

                const int loopCountForAverage = 100000;

                int loopCount = 0;
                while (loopCount++ < loopCountForAverage)
                {
                    // Runs the performance test.
                    for (int i = 0; i < accessCount; i++)
                    {
                        foreach (TestItem testItem in testItems)
                        {
                            if (i == 0)
                                testItem.CreateTestable();

                            stopwatch.Restart();
                            testItem.Testable.RunTest(i);
                            stopwatch.Stop();

                            testItem.TotalTicks += stopwatch.ElapsedTicks;
                        }
                    }
                }

                // Outputs the performance test result.
                foreach (TestItem testItem in testItems)
                {
                    string typeName = testItem.Testable.GetType().Name;
                    int propertyCount = int.Parse(new string(typeName.SkipWhile(p => char.IsNumber(p) == false).ToArray()));

                    Console.WriteLine();
                    Console.Write("[{0}P {1}A] ", propertyCount, accessCount);

                    Console.Write(new string(typeName.Skip("Sample".Length).TakeWhile(p => char.IsNumber(p) == false).ToArray()) + ": ");
                    Console.Write(testItem.TotalTicks / (accessCount * loopCountForAverage));
                    Console.Write("  ");
                }

                Console.WriteLine();
            }

            // Outputs the Frequency.
            Console.WriteLine();
            Console.WriteLine(string.Format("Frequency in ticks per second: {0:N0}", Stopwatch.Frequency));
            Console.WriteLine();
        }
    }
}
