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
    class SampleA50 : PropertyObservable, ITestable
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

        public int TestProperty26
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty27
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty28
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty29
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty30
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty31
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty32
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty33
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty34
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty35
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty36
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty37
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty38
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty39
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty40
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty41
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty42
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty43
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty44
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty45
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty46
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty47
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty48
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty49
        {
            get { return GetProperty<int>(); }
            set { SetProperty(value); }
        }

        public int TestProperty50
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

            int testProperty26 = TestProperty26;
            TestProperty26 = 26 + iterationIndex;

            int testProperty27 = TestProperty27;
            TestProperty27 = 27 + iterationIndex;

            int testProperty28 = TestProperty28;
            TestProperty28 = 28 + iterationIndex;

            int testProperty29 = TestProperty29;
            TestProperty29 = 29 + iterationIndex;

            int testProperty30 = TestProperty30;
            TestProperty30 = 30 + iterationIndex;

            int testProperty31 = TestProperty31;
            TestProperty31 = 31 + iterationIndex;

            int testProperty32 = TestProperty32;
            TestProperty32 = 32 + iterationIndex;

            int testProperty33 = TestProperty33;
            TestProperty33 = 33 + iterationIndex;

            int testProperty34 = TestProperty34;
            TestProperty34 = 34 + iterationIndex;

            int testProperty35 = TestProperty35;
            TestProperty35 = 35 + iterationIndex;

            int testProperty36 = TestProperty36;
            TestProperty36 = 36 + iterationIndex;

            int testProperty37 = TestProperty37;
            TestProperty37 = 37 + iterationIndex;

            int testProperty38 = TestProperty38;
            TestProperty38 = 38 + iterationIndex;

            int testProperty39 = TestProperty39;
            TestProperty39 = 39 + iterationIndex;

            int testProperty40 = TestProperty40;
            TestProperty40 = 40 + iterationIndex;

            int testProperty41 = TestProperty41;
            TestProperty41 = 41 + iterationIndex;

            int testProperty42 = TestProperty42;
            TestProperty42 = 42 + iterationIndex;

            int testProperty43 = TestProperty43;
            TestProperty43 = 43 + iterationIndex;

            int testProperty44 = TestProperty44;
            TestProperty44 = 44 + iterationIndex;

            int testProperty45 = TestProperty45;
            TestProperty45 = 45 + iterationIndex;

            int testProperty46 = TestProperty46;
            TestProperty46 = 46 + iterationIndex;

            int testProperty47 = TestProperty47;
            TestProperty47 = 47 + iterationIndex;

            int testProperty48 = TestProperty48;
            TestProperty48 = 48 + iterationIndex;

            int testProperty49 = TestProperty49;
            TestProperty49 = 49 + iterationIndex;

            int testProperty50 = TestProperty50;
            TestProperty50 = 50 + iterationIndex;
        }

        #endregion
    }
}
