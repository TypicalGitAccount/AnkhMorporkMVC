using AnkhMorporkMVC.GameLogic.States;
using NUnit.Framework;
using System;

namespace AnkhMorporkMVC.Tests.GameLogic.States
{
    public class ThieveStateTest
    {
        private ThieveState state;

        [SetUp]
        public void SetUp()
        {
            state = new ThieveState("TestDummy");
        }

        [Test]
        public void TheftsHappened_NegativeValuePassed_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ThieveState.TheftsHappened = -2);
        }
    }
}
