/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.04.26
 * Version  $Id$
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.ComponentModel;

namespace WatchableObjectPerformanceTest
{
    /// <summary>
    /// The sample class that uses auto property storage.
    /// </summary>
    class SampleA25 : PropertyObservableObject, ITestable
    {
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

        public int TestProperty13
        {
            get { return GetProperty<int>("TestProperty13"); }
            set { SetProperty("TestProperty13", value); }
        }

        public int TestProperty14
        {
            get { return GetProperty<int>("TestProperty14"); }
            set { SetProperty("TestProperty14", value); }
        }

        public int TestProperty15
        {
            get { return GetProperty<int>("TestProperty15"); }
            set { SetProperty("TestProperty15", value); }
        }

        public int TestProperty16
        {
            get { return GetProperty<int>("TestProperty16"); }
            set { SetProperty("TestProperty16", value); }
        }

        public int TestProperty17
        {
            get { return GetProperty<int>("TestProperty17"); }
            set { SetProperty("TestProperty17", value); }
        }

        public int TestProperty18
        {
            get { return GetProperty<int>("TestProperty18"); }
            set { SetProperty("TestProperty18", value); }
        }

        public int TestProperty19
        {
            get { return GetProperty<int>("TestProperty19"); }
            set { SetProperty("TestProperty19", value); }
        }

        public int TestProperty20
        {
            get { return GetProperty<int>("TestProperty20"); }
            set { SetProperty("TestProperty20", value); }
        }

        public int TestProperty21
        {
            get { return GetProperty<int>("TestProperty21"); }
            set { SetProperty("TestProperty21", value); }
        }

        public int TestProperty22
        {
            get { return GetProperty<int>("TestProperty22"); }
            set { SetProperty("TestProperty22", value); }
        }

        public int TestProperty23
        {
            get { return GetProperty<int>("TestProperty23"); }
            set { SetProperty("TestProperty23", value); }
        }

        public int TestProperty24
        {
            get { return GetProperty<int>("TestProperty24"); }
            set { SetProperty("TestProperty24", value); }
        }

        public int TestProperty25
        {
            get { return GetProperty<int>("TestProperty25"); }
            set { SetProperty("TestProperty25", value); }
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

            int testProperty13 = TestProperty13;
            TestProperty13 = 13 + iterationIndex;

            int testProperty14 = TestProperty14;
            TestProperty14 = 14 + iterationIndex;

            int testProperty15 = TestProperty15;
            TestProperty15 = 15 + iterationIndex;

            int testProperty16 = TestProperty16;
            TestProperty16 = 16 + iterationIndex;

            int testProperty17 = TestProperty17;
            TestProperty17 = 17 + iterationIndex;

            int testProperty18 = TestProperty18;
            TestProperty18 = 18 + iterationIndex;

            int testProperty19 = TestProperty19;
            TestProperty19 = 19 + iterationIndex;

            int testProperty20 = TestProperty20;
            TestProperty20 = 20 + iterationIndex;

            int testProperty21 = TestProperty21;
            TestProperty21 = 21 + iterationIndex;

            int testProperty22 = TestProperty22;
            TestProperty22 = 22 + iterationIndex;

            int testProperty23 = TestProperty23;
            TestProperty23 = 23 + iterationIndex;

            int testProperty24 = TestProperty24;
            TestProperty24 = 24 + iterationIndex;

            int testProperty25 = TestProperty25;
            TestProperty25 = 25 + iterationIndex;
        }

        #endregion
    }
}
