/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.09.18
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicenis;
using System;
using System.Collections;

namespace NicenisTests
{
    [TestClass]
    public class WeakEventHandlerTests
    {
        #region Helpers

        int _raiseCount = 0;
        int _raiseCount2 = 0;

        private void EventHandler_Increase_RaiseCount(object sender, EventArgs e)
        {
            _raiseCount++;
        }

        private void EventHandler_Increase_RaiseCount2(object sender, EventArgs e)
        {
            _raiseCount2++;
        }

        static int _staticRaiseCount = 0;
        static int _staticRaiseCount2 = 0;

        private static void EventHandler_Increase_StaticRaiseCount(object sender, EventArgs e)
        {
            _staticRaiseCount++;
        }

        private static void EventHandler_Increase_StaticRaiseCount2(object sender, EventArgs e)
        {
            _staticRaiseCount2++;
        }

        class WeakEventHandlerTest
        {
            WeakEventHandler _weakEventHandler;
            int _value = 0;


            #region Constructors

            public WeakEventHandlerTest(WeakEventHandler weakEventHandler)
            {
                if (weakEventHandler == null)
                    throw new ArgumentNullException("weakEventHandler");

                _weakEventHandler = weakEventHandler;
            }

            #endregion


            #region Helpers

            private void IncreaseStaticRaiseCount(object sender, EventArgs e)
            {
                _staticRaiseCount++;
            }

            private void IncreaseStaticRaiseCount2(object sender, EventArgs e)
            {
                _staticRaiseCount2++;
            }

            private static void StaticIncreaseStaticRaiseCount(object sender, EventArgs e)
            {
                _staticRaiseCount++;
            }

            private static void StaticIncreaseStaticRaiseCount2(object sender, EventArgs e)
            {
                _staticRaiseCount2++;
            }

            #endregion


            #region Public Methods

            public void Add_Instance_Method_Increase_StaticRaiseCount()
            {
                _weakEventHandler.Add(IncreaseStaticRaiseCount);
            }

            public void Add_Instance_Method_Increase_StaticRaiseCount2()
            {
                _weakEventHandler.Add(IncreaseStaticRaiseCount2);
            }

            public void Add_Static_Method_Increase_StaticRaiseCount()
            {
                _weakEventHandler.Add(StaticIncreaseStaticRaiseCount);
            }

            public void Add_Static_Method_Increase_StaticRaiseCount2()
            {
                _weakEventHandler.Add(StaticIncreaseStaticRaiseCount2);
            }

            public void Add_Instance_Lambda_Increase_StaticRaiseCount()
            {
                _weakEventHandler.Add((_, __) => { _value++; _staticRaiseCount++; });
            }

            public void Add_Instance_Lambda_Increase_StaticRaiseCount2()
            {
                _weakEventHandler.Add((_, __) => { _value++; _staticRaiseCount2++; });
            }

            public void Add_Static_Lambda_Increase_StaticRaiseCount()
            {
                _weakEventHandler.Add((_, __) => _staticRaiseCount++);
            }

            public void Add_Static_Lambda_Increase_StaticRaiseCount2()
            {
                _weakEventHandler.Add((_, __) => _staticRaiseCount2++);
            }

            #endregion
        }

        #endregion

        [TestMethod]
        public void WeakEventHandler_Must_Call_EventHandler_Added_By_One_Inline_Instance_Lambda()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _raiseCount = 0;
            weakEventHandler += (_, __) => _raiseCount++;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Call_EventHandler_Added_By_One_Inline_Static_Lambda()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _staticRaiseCount = 0;
            weakEventHandler += (_, __) => _staticRaiseCount++;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Call_EventHandler_Added_By_One_Instance_Method()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _raiseCount = 0;
            weakEventHandler += EventHandler_Increase_RaiseCount;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Call_EventHandler_Added_By_One_Static_Method()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _staticRaiseCount = 0;
            weakEventHandler += EventHandler_Increase_StaticRaiseCount;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Call_EventHandler_Added_By_Two_Inline_Instance_Lambda()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _raiseCount = 0;
            _raiseCount2 = 0;
            weakEventHandler += (_, __) => _raiseCount++;
            weakEventHandler += (_, __) => _raiseCount2++;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Call_EventHandler_Added_By_Two_Inline_Static_Lambda()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            weakEventHandler += (_, __) => _staticRaiseCount++;
            weakEventHandler += (_, __) => _staticRaiseCount2++;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Call_EventHandler_Added_By_Two_Instance_Method()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _raiseCount = 0;
            _raiseCount2 = 0;
            weakEventHandler += EventHandler_Increase_RaiseCount;
            weakEventHandler += EventHandler_Increase_RaiseCount2;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Call_EventHandler_Added_By_Two_Static_Method()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            weakEventHandler += EventHandler_Increase_StaticRaiseCount;
            weakEventHandler += EventHandler_Increase_StaticRaiseCount2;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Does_Not_Support_Removing_EventHandler_By_Inline_Instance_Lambda()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _raiseCount = 0;
            _raiseCount2 = 0;
            weakEventHandler += (_, __) => _raiseCount++;
            weakEventHandler += (_, __) => _raiseCount2++;
            weakEventHandler -= (_, __) => _raiseCount2++;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Does_Not_Support_Removing_EventHandler_By_Inline_Static_Lambda()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            weakEventHandler += (_, __) => _staticRaiseCount++;
            weakEventHandler += (_, __) => _staticRaiseCount2++;
            weakEventHandler -= (_, __) => _staticRaiseCount2++;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Not_Call_EventHandler_Removed_By_Instance_Lambda()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _raiseCount = 0;
            _raiseCount2 = 0;
            EventHandler eventHandler = (_, __) => _raiseCount++;
            EventHandler eventHandler2 = (_, __) => _raiseCount2++;
            weakEventHandler += eventHandler;
            weakEventHandler += eventHandler2;
            weakEventHandler -= eventHandler2;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 0);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Not_Call_EventHandler_Removed_By_Static_Lambda()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            EventHandler eventHandler = (_, __) => _staticRaiseCount++;
            EventHandler eventHandler2 = (_, __) => _staticRaiseCount2++;
            weakEventHandler += eventHandler;
            weakEventHandler += eventHandler2;
            weakEventHandler -= eventHandler2;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 0);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Not_Call_EventHandler_Removed_By_Instance_Method()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _raiseCount = 0;
            _raiseCount2 = 0;
            weakEventHandler += EventHandler_Increase_RaiseCount;
            weakEventHandler += EventHandler_Increase_RaiseCount2;
            weakEventHandler -= EventHandler_Increase_RaiseCount2;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 0);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Not_Call_EventHandler_Removed_By_Static_Method()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            weakEventHandler += EventHandler_Increase_StaticRaiseCount;
            weakEventHandler += EventHandler_Increase_StaticRaiseCount2;
            weakEventHandler -= EventHandler_Increase_StaticRaiseCount2;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 0);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Not_Call_EventHandler_Removed_All()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            _raiseCount = 0;
            _staticRaiseCount = 0;
            weakEventHandler += EventHandler_Increase_RaiseCount;
            weakEventHandler += EventHandler_Increase_StaticRaiseCount;
            weakEventHandler -= EventHandler_Increase_RaiseCount;
            weakEventHandler -= EventHandler_Increase_StaticRaiseCount;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 0);
            Assert.IsTrue(_staticRaiseCount == 0);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Not_Call_Instance_Method_EventHandler_Removed_By_Garbage_Collector()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            WeakEventHandlerTest weakEventHandlerTest = new WeakEventHandlerTest(weakEventHandler);
            _staticRaiseCount = 0;
            weakEventHandlerTest.Add_Instance_Method_Increase_StaticRaiseCount();
            weakEventHandlerTest = null;
            GC.Collect();

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 0);
        }

        [TestMethod]
        public void WeakEventHandler_Does_Not_Support_Removing_Static_Method_EventHandler_By_Garbage_Collector()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            WeakEventHandlerTest weakEventHandlerTest = new WeakEventHandlerTest(weakEventHandler);
            _staticRaiseCount = 0;
            weakEventHandlerTest.Add_Static_Method_Increase_StaticRaiseCount();
            weakEventHandlerTest = null;
            GC.Collect();

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Not_Call_Instance_Lambda_EventHandler_Removed_By_Garbage_Collector()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            WeakEventHandlerTest weakEventHandlerTest = new WeakEventHandlerTest(weakEventHandler);
            _staticRaiseCount = 0;
            weakEventHandlerTest.Add_Instance_Lambda_Increase_StaticRaiseCount();
            weakEventHandlerTest = null;
            GC.Collect();

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 0);
        }

        [TestMethod]
        public void WeakEventHandler_Does_Not_Support_Removing_Static_Lambda_EventHandler_By_Garbage_Collector()
        {
            // arrange
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            WeakEventHandlerTest weakEventHandlerTest = new WeakEventHandlerTest(weakEventHandler);
            _staticRaiseCount = 0;
            weakEventHandlerTest.Add_Static_Lambda_Increase_StaticRaiseCount();
            weakEventHandlerTest = null;
            GC.Collect();

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Support_Addition_Binary_Operator()
        {
            // arrange
            _raiseCount = 0;
            _raiseCount2 = 0;
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            WeakEventHandler weakEventHandler1 = new WeakEventHandler();
            weakEventHandler1 += (_, __) => _raiseCount++;
            weakEventHandler1 += (_, __) => _raiseCount2++;

            WeakEventHandler weakEventHandler2 = new WeakEventHandler();
            weakEventHandler2 += (_, __) => _staticRaiseCount++;
            weakEventHandler2 += (_, __) => _staticRaiseCount2++;

            WeakEventHandler weakEventHandler3 = weakEventHandler1 + weakEventHandler2;

            // act
            weakEventHandler3.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 1);
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Support_Adding_WeakEventHandler()
        {
            // arrange
            _raiseCount = 0;
            _raiseCount2 = 0;
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            weakEventHandler += (_, __) => _raiseCount++;
            weakEventHandler += (_, __) => _raiseCount2++;

            WeakEventHandler weakEventHandlerToAdd = new WeakEventHandler();
            weakEventHandlerToAdd += (_, __) => _staticRaiseCount++;
            weakEventHandlerToAdd += (_, __) => _staticRaiseCount2++;

            weakEventHandler.Add(weakEventHandlerToAdd);

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 1);
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEventHandler_Support_Subtraction_Binary_Operator()
        {
            // arrange
            _raiseCount = 0;
            _raiseCount2 = 0;
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            EventHandler eventHandler1 = (_, __) => _raiseCount++;
            EventHandler eventHandler2 = (_, __) => _raiseCount2++;
            EventHandler eventHandler3 = (_, __) => _staticRaiseCount++;
            EventHandler eventHandler4 = (_, __) => _staticRaiseCount2++;

            WeakEventHandler weakEventHandler1 = new WeakEventHandler();
            weakEventHandler1 += eventHandler1;
            weakEventHandler1 += eventHandler2;
            weakEventHandler1 += eventHandler3;
            weakEventHandler1 += eventHandler4;

            WeakEventHandler weakEventHandler2 = new WeakEventHandler();
            weakEventHandler2 += eventHandler2;
            weakEventHandler2 += eventHandler4;

            WeakEventHandler weakEventHandler3 = weakEventHandler1 - weakEventHandler2;

            // act
            weakEventHandler3.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 0);
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 0);
        }

        [TestMethod]
        public void WeakEventHandler_Support_Removing_WeakEventHandler()
        {
            // arrange
            _raiseCount = 0;
            _raiseCount2 = 0;
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            EventHandler eventHandler1 = (_, __) => _raiseCount++;
            EventHandler eventHandler2 = (_, __) => _raiseCount2++;
            EventHandler eventHandler3 = (_, __) => _staticRaiseCount++;
            EventHandler eventHandler4 = (_, __) => _staticRaiseCount2++;

            WeakEventHandler weakEventHandler = new WeakEventHandler();
            weakEventHandler += eventHandler1;
            weakEventHandler += eventHandler2;
            weakEventHandler += eventHandler3;
            weakEventHandler += eventHandler4;

            WeakEventHandler weakEventHandlerToRemove = new WeakEventHandler();
            weakEventHandlerToRemove += eventHandler2;
            weakEventHandlerToRemove += eventHandler4;

            weakEventHandler.Remove(weakEventHandlerToRemove);

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 0);
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 0);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Remove_One_Handler_Per_One_Minus_Operator()
        {
            // arrange
            _raiseCount = 0;
            EventHandler eventHandler = (_, __) => _raiseCount++;
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            weakEventHandler += eventHandler;
            weakEventHandler += eventHandler;
            weakEventHandler += eventHandler;
            weakEventHandler -= eventHandler;

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 2);
        }

        [TestMethod]
        public void WeakEventHandler_Must_Remove_Exact_Number_Of_Sepcified_Event_Handlers()
        {
            // arrange
            _raiseCount = 0;
            EventHandler eventHandler = (_, __) => _raiseCount++;
            WeakEventHandler weakEventHandler = new WeakEventHandler();
            weakEventHandler += eventHandler;
            weakEventHandler += eventHandler;
            weakEventHandler += eventHandler;
            weakEventHandler += eventHandler;

            WeakEventHandler weakEventHandlerForRemove = new WeakEventHandler();
            weakEventHandlerForRemove += eventHandler;
            weakEventHandlerForRemove += eventHandler;

            weakEventHandler.Remove(weakEventHandlerForRemove);

            // act
            weakEventHandler.Invoke(this);

            // assert
            Assert.IsTrue(_raiseCount == 2);
        }
    }
}
