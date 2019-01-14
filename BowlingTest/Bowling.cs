using System;

namespace BowlingTest
{
    public class Bowling
    {
        private int _score;

        public void Roll(int score)
        {
            _score += score;
        }

        public int Score()
        {
            return _score;
        }
    }
}