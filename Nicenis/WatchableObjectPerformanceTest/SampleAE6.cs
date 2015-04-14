/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.04.26
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.ComponentModel;

namespace WatchableObjectPerformanceTest
{
    /// <summary>
    /// The sample class that uses auto property storage and property expression.
    /// </summary>
    class SampleAE6 : PropertyObservable, ITestable
    {
        public int TestProperty1
        {
            get { return GetProperty(() => TestProperty1); }
            set { SetProperty(() => TestProperty1, value); }
        }

        public int TestProperty2
        {
            get { return GetProperty(() => TestProperty2); }
            set { SetProperty(() => TestProperty2, value); }
        }

        public int TestProperty3
        {
            get { return GetProperty(() => TestProperty3); }
            set { SetProperty(() => TestProperty3, value); }
        }

        public int TestProperty4
        {
            get { return GetProperty(() => TestProperty4); }
            set { SetProperty(() => TestProperty4, value); }
        }

        public int TestProperty5
        {
            get { return GetProperty(() => TestProperty5); }
            set { SetProperty(() => TestProperty5, value); }
        }

        public int TestProperty6
        {
            get { return GetProperty(() => TestProperty6); }
            set { SetProperty(() => TestProperty6, value); }
        }

        #region RunTest

        public void RunTest(int iterationIndex)
        {
            int testProperty1 = TestProperty1;
            TestProperty1 = 1 + iterationIndex;

            int testProperty2 = TestProperty2;
            TestProperty2 = 2 + iterationIndex;

            int testProperty3 = TestProperty3;
            TestProperty3 = 3 + iterationIndex;

            int testProperty4 = TestProperty4;
            TestProperty4 = 4 + iterationIndex;

            int testProperty5 = TestProperty5;
            TestProperty5 = 5 + iterationIndex;

            int testProperty6 = TestProperty6;
            TestProperty6 = 6 + iterationIndex;
        }

        #endregion
    }
}
