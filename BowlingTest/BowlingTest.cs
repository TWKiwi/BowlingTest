using System.Collections.Generic;
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

        [TestMethod]
        public void RollTwentyBalls_HasOneSpire_Ver2()
        {
            SetRollHistory(new List<int>()
            {
                3,1,3,7,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(49, _bowling.Score());
        }

        [TestMethod]
        public void RollTwentyBalls_HasTwoSpire()
        {
            SetRollHistory(new List<int>()
            {
                3,1,3,7,3,1,3,1,3,1,3,7,3,1,3,1,3,1,3,1,
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(58, _bowling.Score());
        }

        [TestMethod]
        public void RollTwentyBalls_SpireContinuous()
        {
            SetRollHistory(new List<int>()
            {
                3,7,3,7,3,7,3,1,3,1,3,7,3,1,3,1,3,1,3,1,
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(76, _bowling.Score());
        }

        [TestMethod]
        public void RollTwentyOneBalls_AllSpire_LastRollThree()
        {
            SetRollHistory(new List<int>()
            {
                3,7,3,7,3,7,3,7,3,7,3,7,3,7,3,7,3,7,3,7,3
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(130, _bowling.Score());
        }

        [TestMethod]
        public void RollTwentyOneBalls_AllSpire_LastRollFive()
        {
            SetRollHistory(new List<int>()
            {
                0,10,0,10,0,10,0,10,0,10,0,10,0,10,0,10,0,10,0,10,5
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(105, _bowling.Score());
        }

        [TestMethod]
        public void RollNineteenBalls_OneStrike()
        {
            SetRollHistory(new List<int>()
            {
                10,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(50, _bowling.Score());
        }

        [TestMethod]
        public void RollEighteenBalls_TwoStrike()
        {
            SetRollHistory(new List<int>()
            {
                10,10,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(69, _bowling.Score());
        }

        [TestMethod]
        public void RollSeventeenBalls_ThreeStrike()
        {
            SetRollHistory(new List<int>()
            {
                10,10,10,3,1,3,1,3,1,3,1,3,1,3,1,3,1
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(95, _bowling.Score());
        }

        [TestMethod]
        public void RollSeventeenBalls_ThreeStrike_ver2()
        {
            SetRollHistory(new List<int>()
            {
                3,1,10,10,10,3,1,3,1,3,1,3,1,3,1,3,1
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(95, _bowling.Score());
        }

        [TestMethod]
        public void RollSeventeenBalls_ThreeStrike_NoContinue()
        {
            SetRollHistory(new List<int>()
            {
                3,1,10,3,1,10,10,3,1,3,1,3,1,3,1,3,1
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(79, _bowling.Score());
        }

        [TestMethod]
        public void RollSeventeenBalls_ThreeStrike_NoContinue_ver2()
        {
            SetRollHistory(new List<int>()
            {
                3,1,10,3,1,10,3,1,10,3,1,3,1,3,1,3,1
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(70, _bowling.Score());
        }

        [TestMethod]
        public void RollTwentyOneBalls_EndAsSpire()
        {
            SetRollHistory(new List<int>()
            {
                3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,7,7
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(53, _bowling.Score());
        }

        [TestMethod]
        public void RollTwentyOneBalls_EndAsSpire_Ver2()
        {
            SetRollHistory(new List<int>()
            {
                3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,7,3,7,7
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(62, _bowling.Score());
        }

        [TestMethod]
        public void RollTwentyOneBalls_EndAsStrike()
        {
            SetRollHistory(new List<int>()
            {
                3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,10,0,8
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(54, _bowling.Score());
        }

        [TestMethod]
        public void RollTwentyOneBalls_EndAsStrike_Ver2()
        {
            SetRollHistory(new List<int>()
            {
                3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,10,10,8
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(64, _bowling.Score());
        }

        [TestMethod]
        public void RollTwentyOneBalls_EndAsStrike_Ver3()
        {
            SetRollHistory(new List<int>()
            {
                3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,10,10,10
            });

            RollBalls(_rollHistory);

            Assert.AreEqual(66, _bowling.Score());
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


