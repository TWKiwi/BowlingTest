using System;

namespace BowlingTest
{
    public class Bowling
    {
        private int _score;
        private int _ballsCount;
        private int _framesCount;

        public void Roll(int score)
        {
            _ballsCount++;
            if (_ballsCount % 2 == 0)
            {
                _framesCount++;
            }
            _score += score;
        }

        public int Score()
        {
            if (_framesCount == 0)
            {
                return 0;
            }

            return _score;
        }
    }
}