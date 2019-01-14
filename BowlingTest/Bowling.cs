using System.Collections.Generic;
using System.Linq;

namespace BowlingTest
{
    public class Bowling
    {
        private int _ballsCount;
        private int _framesCount;
        public List<Frame> Frames = new List<Frame>();
        private int _tempTotalScore;

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
            NewFrameCounter();
            _tempTotalScore += score;
            if (!IsNewFrame())
            {
                Frames[_framesCount - 1].Score += _tempTotalScore;
            }
        }

        private void NewFrameCounter()
        {
            if (IsNewFrame())
            {
                _tempTotalScore = 0;
                _framesCount++;
            }
        }

        private bool IsNewFrame()
        {
            return _ballsCount % 2 == 1;
        }

        private int UpdateTotalScore()
        {
            return Frames.Sum(x => x.Score);
        }

        public int Score()
        {
            return UpdateTotalScore();
        }
    }

    public class Frame
    {
        public int Score;
    }
}