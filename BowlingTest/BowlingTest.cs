using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingTest
{
    [TestClass]
    public class BowlingTest
    {
        [TestMethod]
        public void RollOneBall_NoStrikeAndSpire()
        { 
            var bowling = new Bowling();

            bowling.Roll(1);

            Assert.AreEqual(0, bowling.Score());
        }

        [TestMethod]
        public void RollTwoBalls_NoStrikeAndSpire_FramesCountShouldBeOne()
        {
            var bowling = new Bowling();

            bowling.Roll(3);
            bowling.Roll(1);

            Assert.AreEqual(4, bowling.Score());
        }
    }
}


