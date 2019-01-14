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
        private int _spireBonusTimes;

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
            HasSpireBonus(score);
            if (!IsNewFrame())
            {
                Frames[_framesCount - 1].Score += _tempTotalScore;
            }
            if (IsSpire())
            {
                _spireBonusTimes++;
            }
        }

        private void HasSpireBonus(int score)
        {
            if (_spireBonusTimes>0)
            {
                Frames[_framesCount - 1].Score += score;
                _spireBonusTimes--;
            }
        }

        private bool IsSpire()
        {
            return Frames[_framesCount - 1].Score == 10;
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