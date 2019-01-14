﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingTest
{
    

    [TestClass]
    public class BowlingTest
    {
        private readonly Bowling _bowling = new Bowling();

        private List<int> _rollHistory = new List<int>();

        [TestMethod]
        public void RollOneBall_NoStrikeAndSpire()
        {
            SetRollHistory(new List<int>()
            {
                1,
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(0, _bowling.Score());
        }

        [TestMethod]
        public void RollTwoBalls_NoStrikeAndSpire_FramesCountShouldBeOne()
        {
            SetRollHistory(new List<int>()
            {
                3,1,
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(4, _bowling.Score());
        }

        [TestMethod]
        public void RollTwentyBalls_NoStrikeAndSpire_FramesCountShouldBeTen()
        {
            SetRollHistory(new List<int>()
            {
                3,1 ,3,1 ,3,1 ,3,1 ,3,1 ,3,1 ,3,1 ,3,1 ,3,1 ,3,1,
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(40, _bowling.Score());
        }

        [TestMethod]
        public void RollTwentyBalls_HasOneSpire()
        {
            SetRollHistory(new List<int>()
            {
                3,7 ,3,1 ,3,1 ,3,1 ,3,1 ,3,1 ,3,1 ,3,1 ,3,1 ,3,1
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(49, _bowling.Score());
        }

        private void SetRollHistory(List<int> dictionary)
        {
            _rollHistory = dictionary;
        }

        private void RollBalls(List<int> rollHistory)
        {
            foreach (var score in rollHistory)
            {
                _bowling.Roll(score);
            }
        }
    }
}


