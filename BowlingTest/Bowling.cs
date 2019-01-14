using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingTest
{
    public class Bowling
    {
        private int _score;
        private int _ballsCount;
        private int _framesCount;
        public List<Frame> Frames = new List<Frame>();
        

        public Bowling()
        {
            for (int i = 0; i < 10; i++)
            {
                Frames.Add(new Frame());
            }
        }

        public void Roll(int score)
        {
            _ballsCount++;
            IsNewFram();
            Frames[_framesCount].Score += score;
        }

        private void IsNewFram()
        {
            if (_ballsCount % 2 == 0)
            {
                _framesCount++;
            }
        }

        public int Score()
        {
            return _framesCount == 0 ? 0 : ComputeScore();
        }

        private int ComputeScore()
        {
            return Frames.Sum(x => x.Score);
        }
    }

    public class Frame
    {
        public int Score;
    }
}