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

            Assert.AreEqual(1, bowling.Score());
        }
    }
}


