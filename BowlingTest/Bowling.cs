using System.Collections.Generic;
using System.Linq;

namespace BowlingTest
{
    public class Bowling
    {
        private int _framesCount;
        public List<Frame> Frames = new List<Frame>();
        private int _tempTotalScore;
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
            FrameBonusProcess();
            if (_youHaveNoChance) return;
            SetUpCounter();
            _tempTotalScore += score;
            SpireBonusProcess(score);
            StrikeBonusProcess(score);

            SpireBonusActivation();
            StrikeBonusActivation();

            CurrentFrameFinished();
        }

        private void CurrentFrameFinished()
        {
            if (!_isFirstBall)
            {
                FrameCompleted();
                SetUpScoreIntoCurrentFrame();
                _tempTotalScore = 0;
                _framesCount++;
                _isFirstBall = false;
            }

            if (_isFrameBonus)
            {
                _tempTotalScore = 0;
                _framesCount++;
                _isFirstBall = false;
            }
        }

        private void StrikeBonusActivation()
        {
            if (IsStrike() && !_isFrameBonus)
            {
                Frames[CurrentFrameIndex].StrikeBonusTimes += 2;
                _isFirstBall = _isFrameBonus;
            }
        }

        private void SpireBonusActivation()
        {
            if (IsSpire() && !_isFrameBonus)
            {
                Frames[CurrentFrameIndex].SpireBonusTimes++;
            }
        }

        private void FrameBonusProcess()
        {
            if (_isFrameBonus)
            {
                _framesCount--;
                Frames[CurrentFrameIndex].IsCompleted = false;
            }
        }

        private void IsReachTheUpperLimit()
        {
            if (CurrentFrameIndex >= 10 && HaveBonusChance())
            {
                _isFrameBonus = true;
            }
            else if (NoBonusChance())
            {
                _youHaveNoChance = true;
            }
        }

        private bool NoBonusChance()
        {
            return Frames.Any(x => x.SpireBonusTimes < 0 && x.StrikeBonusTimes < 0);
        }

        private bool HaveBonusChance()
        {
            return Frames.Any(x => x.SpireBonusTimes > 0 || x.StrikeBonusTimes > 0);
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

        private void StrikeBonusProcess(int score)
        {
            var enumerable = Frames.Where(x => x.StrikeBonusTimes > 0);
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Score += score;
                enumerator.Current.StrikeBonusTimes--;
            }
        }

        private bool IsStrike()
        {
            return _tempTotalScore == 10 && _isFirstBall;
        }

        private void SetUpCounter()
        {
            _isFirstBall = !_isFirstBall || _isFrameBonus;
        }

        private void SpireBonusProcess(int score)
        {
            var enumerable = Frames.Where(x => x.SpireBonusTimes > 0);
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Score += score;
                enumerator.Current.SpireBonusTimes--;
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
        public int StrikeBonusTimes { get; set; }
        public int SpireBonusTimes { get; set; }
    }
}