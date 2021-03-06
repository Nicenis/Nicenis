﻿/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.04.26
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.ComponentModel;

namespace PropertyObservablePerformanceTest
{
    /// <summary>
    /// The sample class that uses local property storage.
    /// </summary>
    class SampleL6 : PropertyObservable, ITestable
    {
        int _testProperty1;

        public int TestProperty1
        {
            get { return _testProperty1; }
            set { SetProperty(ref _testProperty1, value); }
        }

        int _testProperty2;

        public int TestProperty2
        {
            get { return _testProperty2; }
            set { SetProperty(ref _testProperty2, value); }
        }

        int _testProperty3;

        public int TestProperty3
        {
            get { return _testProperty3; }
            set { SetProperty(ref _testProperty3, value); }
        }

        int _testProperty4;

        public int TestProperty4
        {
            get { return _testProperty4; }
            set { SetProperty(ref _testProperty4, value); }
        }

        int _testProperty5;

        public int TestProperty5
        {
            get { return _testProperty5; }
            set { SetProperty(ref _testProperty5, value); }
        }

        int _testProperty6;

        public int TestProperty6
        {
            get { return _testProperty6; }
            set { SetProperty(ref _testProperty6, value); }
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
