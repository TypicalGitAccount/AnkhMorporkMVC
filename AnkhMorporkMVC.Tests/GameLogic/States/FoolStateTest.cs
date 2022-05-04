﻿
using AnkhMorporkMVC.GameLogic.PredefinedData;
using AnkhMorporkMVC.GameLogic.States;
using NUnit.Framework;
using System;

namespace AnkhMorporkMVC.Tests.GameLogic.States
{
    public class FoolStateTest
    {
        private FoolState state;

        [SetUp]
        public void SetUp()
        {
            state = new FoolState("TestDummy", FoolRewardPennies.ArchFool.ToString(), (int)FoolRewardPennies.ArchFool);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CharacterName_InvalidStringPassed_ThrowsArgumentOutOfRangeException(string input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => state.PracticeName = input);
        }
    }
}
