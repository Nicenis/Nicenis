/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.04.26
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.ComponentModel;

namespace PropertyObservablePerformanceTest
{
    /// <summary>
    /// The sample class that uses auto property storage.
    /// </summary>
    class SampleA25 : PropertyObservable, ITestable
    {
        public int TestProperty1
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty2
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty3
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty4
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty5
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty6
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty7
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty8
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty9
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty10
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty11
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty12
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty13
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty14
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty15
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty16
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty17
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty18
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty19
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty20
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty21
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty22
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty23
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty24
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty25
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
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
