using System.Collections.Generic;
using System.Linq;

namespace BowlingTest
{
    public class Bowling
    {
        private int _framesCount;
        public List<Frame> Frames = new List<Frame>();
        private int _tempTotalScore;
        private int _spireBonusTimes;
        private int _strikeBonusTimes;
        private bool _isFirstBall;
        private bool _isFrameBonus;
        private bool _youHaveNoChance;

        public int CurrentFrameIndex => _framesCount - 1;

        public Bowling()
        {
            _framesCount++;
            for (int i = 0; i < 10; i++)
            {
                Frames.Add(new Frame());
            }
        }

        public void Roll(int score)
        {
            IsReachTheUpperLimit();

            if (_isFrameBonus)
            {
                _framesCount--;
            }

            if (_youHaveNoChance) return;
            SetUpCounter();
            _tempTotalScore += score;
            HasSpireBonus(score);
            HasStrikeBonus(score);

            if (IsSpire())
            {
                _spireBonusTimes++;
            }

            if (IsStrike())
            {
                _strikeBonusTimes += 2;
                _isFirstBall = false;
            }


            if (!_isFirstBall)
            {
                FrameCompleted();
                SetUpScoreIntoCurrentFrame();
                _tempTotalScore = 0;
                _framesCount++;
                _isFirstBall = false;
            }
        }

        private void IsReachTheUpperLimit()
        {
            if (CurrentFrameIndex >= 10 && _spireBonusTimes > 0)
            {
                _isFrameBonus = true;
            }
            else if (CurrentFrameIndex >= 10 && _spireBonusTimes < 0 && _strikeBonusTimes < 0)
            {
                _youHaveNoChance = true;
            }
        }

        private void FrameCompleted()
        {
            Frames[CurrentFrameIndex].IsCompleted = true;
        }

        private void SetUpScoreIntoCurrentFrame()
        {
            if (!FrameUnCompleted())
            {
                Frames[CurrentFrameIndex].Score += _tempTotalScore;
            }
        }

        private bool HasExistCompletedFrame()
        {
            return Frames.Any(x => x.IsCompleted);
        }

        private void HasStrikeBonus(int score)
        {
            if (_strikeBonusTimes > 0 && HasExistCompletedFrame())
            {
                Frames[CurrentFrameIndex - 1].Score += score;
                _strikeBonusTimes--;
            }
        }

        private bool IsStrike()
        {
            return _tempTotalScore == 10 && _isFirstBall;
        }

        private void SetUpCounter()
        {
            _isFirstBall = !_isFirstBall;
        }

        private void HasSpireBonus(int score)
        {
            if (_spireBonusTimes > 0)
            {
                Frames[CurrentFrameIndex - 1].Score += score;
                _spireBonusTimes--;
            }
        }

        private bool IsSpire()
        {
            return _tempTotalScore == 10 && !_isFirstBall;
        }

        private bool FrameUnCompleted()
        {
            return !Frames[CurrentFrameIndex].IsCompleted;
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
        public bool IsCompleted;
    }
}