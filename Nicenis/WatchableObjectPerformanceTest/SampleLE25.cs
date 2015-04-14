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
    /// The sample class that uses local property storage and property expression.
    /// </summary>
    class SampleLE25 : PropertyObservable, ITestable
    {
        int _testProperty1;

        public int TestProperty1
        {
            get { return _testProperty1; }
            set { SetProperty(() => TestProperty1, ref _testProperty1, value); }
        }

        int _testProperty2;

        public int TestProperty2
        {
            get { return _testProperty2; }
            set { SetProperty(() => TestProperty2, ref _testProperty2, value); }
        }

        int _testProperty3;

        public int TestProperty3
        {
            get { return _testProperty3; }
            set { SetProperty(() => TestProperty3, ref _testProperty3, value); }
        }

        int _testProperty4;

        public int TestProperty4
        {
            get { return _testProperty4; }
            set { SetProperty(() => TestProperty4, ref _testProperty4, value); }
        }

        int _testProperty5;

        public int TestProperty5
        {
            get { return _testProperty5; }
            set { SetProperty(() => TestProperty5, ref _testProperty5, value); }
        }

        int _testProperty6;

        public int TestProperty6
        {
            get { return _testProperty6; }
            set { SetProperty(() => TestProperty6, ref _testProperty6, value); }
        }

        int _testProperty7;

        public int TestProperty7
        {
            get { return _testProperty7; }
            set { SetProperty(() => TestProperty7, ref _testProperty7, value); }
        }

        int _testProperty8;

        public int TestProperty8
        {
            get { return _testProperty8; }
            set { SetProperty(() => TestProperty8, ref _testProperty8, value); }
        }

        int _testProperty9;

        public int TestProperty9
        {
            get { return _testProperty9; }
            set { SetProperty(() => TestProperty9, ref _testProperty9, value); }
        }

        int _testProperty10;

        public int TestProperty10
        {
            get { return _testProperty10; }
            set { SetProperty(() => TestProperty10, ref _testProperty10, value); }
        }

        int _testProperty11;

        public int TestProperty11
        {
            get { return _testProperty11; }
            set { SetProperty(() => TestProperty11, ref _testProperty11, value); }
        }

        int _testProperty12;

        public int TestProperty12
        {
            get { return _testProperty12; }
            set { SetProperty(() => TestProperty12, ref _testProperty12, value); }
        }

        int _testProperty13;

        public int TestProperty13
        {
            get { return _testProperty13; }
            set { SetProperty(() => TestProperty13, ref _testProperty13, value); }
        }

        int _testProperty14;

        public int TestProperty14
        {
            get { return _testProperty14; }
            set { SetProperty(() => TestProperty14, ref _testProperty14, value); }
        }

        int _testProperty15;

        public int TestProperty15
        {
            get { return _testProperty15; }
            set { SetProperty(() => TestProperty15, ref _testProperty15, value); }
        }

        int _testProperty16;

        public int TestProperty16
        {
            get { return _testProperty16; }
            set { SetProperty(() => TestProperty16, ref _testProperty16, value); }
        }

        int _testProperty17;

        public int TestProperty17
        {
            get { return _testProperty17; }
            set { SetProperty(() => TestProperty17, ref _testProperty17, value); }
        }

        int _testProperty18;

        public int TestProperty18
        {
            get { return _testProperty18; }
            set { SetProperty(() => TestProperty18, ref _testProperty18, value); }
        }

        int _testProperty19;

        public int TestProperty19
        {
            get { return _testProperty19; }
            set { SetProperty(() => TestProperty19, ref _testProperty19, value); }
        }

        int _testProperty20;

        public int TestProperty20
        {
            get { return _testProperty20; }
            set { SetProperty(() => TestProperty20, ref _testProperty20, value); }
        }

        int _testProperty21;

        public int TestProperty21
        {
            get { return _testProperty21; }
            set { SetProperty(() => TestProperty21, ref _testProperty21, value); }
        }

        int _testProperty22;

        public int TestProperty22
        {
            get { return _testProperty22; }
            set { SetProperty(() => TestProperty22, ref _testProperty22, value); }
        }

        int _testProperty23;

        public int TestProperty23
        {
            get { return _testProperty23; }
            set { SetProperty(() => TestProperty23, ref _testProperty23, value); }
        }

        int _testProperty24;

        public int TestProperty24
        {
            get { return _testProperty24; }
            set { SetProperty(() => TestProperty24, ref _testProperty24, value); }
        }

        int _testProperty25;

        public int TestProperty25
        {
            get { return _testProperty25; }
            set { SetProperty(() => TestProperty25, ref _testProperty25, value); }
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
