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
    /// The sample class that uses auto property storage.
    /// </summary>
#pragma warning disable 618
    class SampleA12 : WatchableObject, ITestable
    {
#pragma warning restore 618
        public int TestProperty1
        {
            get { return GetProperty<int>("TestProperty1"); }
            set { SetProperty("TestProperty1", value); }
        }

        public int TestProperty2
        {
            get { return GetProperty<int>("TestProperty2"); }
            set { SetProperty("TestProperty2", value); }
        }

        public int TestProperty3
        {
            get { return GetProperty<int>("TestProperty3"); }
            set { SetProperty("TestProperty3", value); }
        }

        public int TestProperty4
        {
            get { return GetProperty<int>("TestProperty4"); }
            set { SetProperty("TestProperty4", value); }
        }

        public int TestProperty5
        {
            get { return GetProperty<int>("TestProperty5"); }
            set { SetProperty("TestProperty5", value); }
        }

        public int TestProperty6
        {
            get { return GetProperty<int>("TestProperty6"); }
            set { SetProperty("TestProperty6", value); }
        }

        public int TestProperty7
        {
            get { return GetProperty<int>("TestProperty7"); }
            set { SetProperty("TestProperty7", value); }
        }

        public int TestProperty8
        {
            get { return GetProperty<int>("TestProperty8"); }
            set { SetProperty("TestProperty8", value); }
        }

        public int TestProperty9
        {
            get { return GetProperty<int>("TestProperty9"); }
            set { SetProperty("TestProperty9", value); }
        }

        public int TestProperty10
        {
            get { return GetProperty<int>("TestProperty10"); }
            set { SetProperty("TestProperty10", value); }
        }

        public int TestProperty11
        {
            get { return GetProperty<int>("TestProperty11"); }
            set { SetProperty("TestProperty11", value); }
        }

        public int TestProperty12
        {
            get { return GetProperty<int>("TestProperty12"); }
            set { SetProperty("TestProperty12", value); }
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
