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
            public TestItem(ITestable testable)
            {
                Debug.Assert(testable != null);
                Testable = testable;
            }

            public ITestable Testable { get; private set; }
            public long TotalTicks { get; set; }
        }

        static void Main(string[] args)
        {
            const int iterationCount = 10000;

            TestItem[] testItems = new TestItem[]
            {
                new TestItem(new SampleL()),
                new TestItem(new SampleLE()),
                new TestItem(new SampleA()),
                new TestItem(new SampleAE()),
            };


            Console.WriteLine("Running performance test... Please wait.");
            Console.WriteLine();

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


            foreach (TestItem testItem in testItems)
                Console.Write(testItem.Testable.GetType().Name + "\t\t");
            Console.WriteLine();

            foreach (TestItem testItem in testItems)
                Console.Write(testItem.TotalTicks / iterationCount + " ticks\t\t");
            Console.WriteLine();
        }
    }
}
