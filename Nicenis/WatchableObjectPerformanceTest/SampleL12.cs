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
    /// The sample class that uses local property storage.
    /// </summary>
    class SampleL12 : WatchableObject, ITestable
    {
        int _testProperty1;

        public int TestProperty1
        {
            get { return _testProperty1; }
            set { SetProperty("TestProperty1", ref _testProperty1, value); }
        }

        int _testProperty2;

        public int TestProperty2
        {
            get { return _testProperty2; }
            set { SetProperty("TestProperty2", ref _testProperty2, value); }
        }

        int _testProperty3;

        public int TestProperty3
        {
            get { return _testProperty3; }
            set { SetProperty("TestProperty3", ref _testProperty3, value); }
        }

        int _testProperty4;

        public int TestProperty4
        {
            get { return _testProperty4; }
            set { SetProperty("TestProperty4", ref _testProperty4, value); }
        }

        int _testProperty5;

        public int TestProperty5
        {
            get { return _testProperty5; }
            set { SetProperty("TestProperty5", ref _testProperty5, value); }
        }

        int _testProperty6;

        public int TestProperty6
        {
            get { return _testProperty6; }
            set { SetProperty("TestProperty6", ref _testProperty6, value); }
        }

        int _testProperty7;

        public int TestProperty7
        {
            get { return _testProperty7; }
            set { SetProperty("TestProperty7", ref _testProperty7, value); }
        }

        int _testProperty8;

        public int TestProperty8
        {
            get { return _testProperty8; }
            set { SetProperty("TestProperty8", ref _testProperty8, value); }
        }

        int _testProperty9;

        public int TestProperty9
        {
            get { return _testProperty9; }
            set { SetProperty("TestProperty9", ref _testProperty9, value); }
        }

        int _testProperty10;

        public int TestProperty10
        {
            get { return _testProperty10; }
            set { SetProperty("TestProperty10", ref _testProperty10, value); }
        }

        int _testProperty11;

        public int TestProperty11
        {
            get { return _testProperty11; }
            set { SetProperty("TestProperty11", ref _testProperty11, value); }
        }

        int _testProperty12;

        public int TestProperty12
        {
            get { return _testProperty12; }
            set { SetProperty("TestProperty12", ref _testProperty12, value); }
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

            int testProperty7 = TestProperty7;
            TestProperty7 = 7 + iterationIndex;

            int testProperty8 = TestProperty8;
            TestProperty8 = 8 + iterationIndex;

            int testProperty9 = TestProperty9;
            TestProperty9 = 9 + iterationIndex;

            int testProperty10 = TestProperty10;
            TestProperty10 = 10 + iterationIndex;

            int testProperty11 = TestProperty11;
            TestProperty11 = 11 + iterationIndex;

            int testProperty12 = TestProperty12;
            TestProperty12 = 12 + iterationIndex;
        }

        #endregion
    }
}
