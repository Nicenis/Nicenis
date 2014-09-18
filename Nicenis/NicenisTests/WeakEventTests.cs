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
    public class WeakEventTests
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

        class WeakEventTest
        {
            WeakEvent _weakEvent;
            int _value = 0;


            #region Constructors

            public WeakEventTest(WeakEvent weakEvent)
            {
                if (weakEvent == null)
                    throw new ArgumentNullException("weakEvent");

                _weakEvent = weakEvent;
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
                _weakEvent.Add(IncreaseStaticRaiseCount);
            }

            public void Add_Instance_Method_Increase_StaticRaiseCount2()
            {
                _weakEvent.Add(IncreaseStaticRaiseCount2);
            }

            public void Add_Static_Method_Increase_StaticRaiseCount()
            {
                _weakEvent.Add(StaticIncreaseStaticRaiseCount);
            }

            public void Add_Static_Method_Increase_StaticRaiseCount2()
            {
                _weakEvent.Add(StaticIncreaseStaticRaiseCount2);
            }

            public void Add_Instance_Lambda_Increase_StaticRaiseCount()
            {
                _weakEvent.Add((_, __) => { _value++; _staticRaiseCount++; });
            }

            public void Add_Instance_Lambda_Increase_StaticRaiseCount2()
            {
                _weakEvent.Add((_, __) => { _value++; _staticRaiseCount2++; });
            }

            public void Add_Static_Lambda_Increase_StaticRaiseCount()
            {
                _weakEvent.Add((_, __) => _staticRaiseCount++);
            }

            public void Add_Static_Lambda_Increase_StaticRaiseCount2()
            {
                _weakEvent.Add((_, __) => _staticRaiseCount2++);
            }

            #endregion
        }

        #endregion

        [TestMethod]
        public void WeakEvent_Must_Call_EventHandler_Added_By_One_Inline_Instance_Lambda()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _raiseCount = 0;
            weakEvent.Add((_, __) => _raiseCount++);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
        }

        [TestMethod]
        public void WeakEvent_Must_Call_EventHandler_Added_By_One_Inline_Static_Lambda()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _staticRaiseCount = 0;
            weakEvent.Add((_, __) => _staticRaiseCount++);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
        }

        [TestMethod]
        public void WeakEvent_Must_Call_EventHandler_Added_By_One_Instance_Method()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _raiseCount = 0;
            weakEvent.Add(EventHandler_Increase_RaiseCount);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
        }

        [TestMethod]
        public void WeakEvent_Must_Call_EventHandler_Added_By_One_Static_Method()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _staticRaiseCount = 0;
            weakEvent.Add(EventHandler_Increase_StaticRaiseCount);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
        }

        [TestMethod]
        public void WeakEvent_Must_Call_EventHandler_Added_By_Two_Inline_Instance_Lambda()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _raiseCount = 0;
            _raiseCount2 = 0;
            weakEvent.Add((_, __) => _raiseCount++);
            weakEvent.Add((_, __) => _raiseCount2++);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEvent_Must_Call_EventHandler_Added_By_Two_Inline_Static_Lambda()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            weakEvent.Add((_, __) => _staticRaiseCount++);
            weakEvent.Add((_, __) => _staticRaiseCount2++);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEvent_Must_Call_EventHandler_Added_By_Two_Instance_Method()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _raiseCount = 0;
            _raiseCount2 = 0;
            weakEvent.Add(EventHandler_Increase_RaiseCount);
            weakEvent.Add(EventHandler_Increase_RaiseCount2);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEvent_Must_Call_EventHandler_Added_By_Two_Static_Method()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            weakEvent.Add(EventHandler_Increase_StaticRaiseCount);
            weakEvent.Add(EventHandler_Increase_StaticRaiseCount2);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEvent_Does_Not_Support_Removing_EventHandler_By_Inline_Instance_Lambda()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _raiseCount = 0;
            _raiseCount2 = 0;
            weakEvent.Add((_, __) => _raiseCount++);
            weakEvent.Add((_, __) => _raiseCount2++);
            weakEvent.Remove((_, __) => _raiseCount2++);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEvent_Does_Not_Support_Removing_EventHandler_By_Inline_Static_Lambda()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            weakEvent.Add((_, __) => _staticRaiseCount++);
            weakEvent.Add((_, __) => _staticRaiseCount2++);
            weakEvent.Remove((_, __) => _staticRaiseCount2++);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 1);
        }

        [TestMethod]
        public void WeakEvent_Must_Not_Call_EventHandler_Removed_By_Instance_Lambda()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _raiseCount = 0;
            _raiseCount2 = 0;
            EventHandler eventHandler = (_, __) => _raiseCount++;
            EventHandler eventHandler2 = (_, __) => _raiseCount2++;
            weakEvent.Add(eventHandler);
            weakEvent.Add(eventHandler2);
            weakEvent.Remove(eventHandler2);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 0);
        }

        [TestMethod]
        public void WeakEvent_Must_Not_Call_EventHandler_Removed_By_Static_Lambda()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            EventHandler eventHandler = (_, __) => _staticRaiseCount++;
            EventHandler eventHandler2 = (_, __) => _staticRaiseCount2++;
            weakEvent.Add(eventHandler);
            weakEvent.Add(eventHandler2);
            weakEvent.Remove(eventHandler2);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 0);
        }

        [TestMethod]
        public void WeakEvent_Must_Not_Call_EventHandler_Removed_By_Instance_Method()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _raiseCount = 0;
            _raiseCount2 = 0;
            weakEvent.Add(EventHandler_Increase_RaiseCount);
            weakEvent.Add(EventHandler_Increase_RaiseCount2);
            weakEvent.Remove(EventHandler_Increase_RaiseCount2);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_raiseCount == 1);
            Assert.IsTrue(_raiseCount2 == 0);
        }

        [TestMethod]
        public void WeakEvent_Must_Not_Call_EventHandler_Removed_By_Static_Method()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _staticRaiseCount = 0;
            _staticRaiseCount2 = 0;
            weakEvent.Add(EventHandler_Increase_StaticRaiseCount);
            weakEvent.Add(EventHandler_Increase_StaticRaiseCount2);
            weakEvent.Remove(EventHandler_Increase_StaticRaiseCount2);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
            Assert.IsTrue(_staticRaiseCount2 == 0);
        }

        [TestMethod]
        public void WeakEvent_Must_Not_Call_EventHandler_Removed_All()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            _raiseCount = 0;
            _staticRaiseCount = 0;
            weakEvent.Add(EventHandler_Increase_RaiseCount);
            weakEvent.Add(EventHandler_Increase_StaticRaiseCount);
            weakEvent.Remove(EventHandler_Increase_RaiseCount);
            weakEvent.Remove(EventHandler_Increase_StaticRaiseCount);

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_raiseCount == 0);
            Assert.IsTrue(_staticRaiseCount == 0);
        }

        [TestMethod]
        public void WeakEvent_Must_Not_Call_Instance_Method_EventHandler_Removed_By_Garbage_Collector()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            WeakEventTest weakEventTest = new WeakEventTest(weakEvent);
            _staticRaiseCount = 0;
            weakEventTest.Add_Instance_Method_Increase_StaticRaiseCount();
            weakEventTest = null;
            GC.Collect();

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 0);
        }

        [TestMethod]
        public void WeakEvent_Does_Not_Support_Removing_Static_Method_EventHandler_By_Garbage_Collector()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            WeakEventTest weakEventTest = new WeakEventTest(weakEvent);
            _staticRaiseCount = 0;
            weakEventTest.Add_Static_Method_Increase_StaticRaiseCount();
            weakEventTest = null;
            GC.Collect();

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
        }

        [TestMethod]
        public void WeakEvent_Must_Not_Call_Instance_Lambda_EventHandler_Removed_By_Garbage_Collector()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            WeakEventTest weakEventTest = new WeakEventTest(weakEvent);
            _staticRaiseCount = 0;
            weakEventTest.Add_Instance_Lambda_Increase_StaticRaiseCount();
            weakEventTest = null;
            GC.Collect();

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 0);
        }

        [TestMethod]
        public void WeakEvent_Does_Not_Support_Removing_Static_Lambda_EventHandler_By_Garbage_Collector()
        {
            // arrange
            WeakEvent weakEvent = new WeakEvent();
            WeakEventTest weakEventTest = new WeakEventTest(weakEvent);
            _staticRaiseCount = 0;
            weakEventTest.Add_Static_Lambda_Increase_StaticRaiseCount();
            weakEventTest = null;
            GC.Collect();

            // act
            weakEvent.Raise(this);

            // assert
            Assert.IsTrue(_staticRaiseCount == 1);
        }
    }
}
