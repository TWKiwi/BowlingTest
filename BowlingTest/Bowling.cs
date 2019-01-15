using System.Collections.Generic;
using System.Linq;

namespace BowlingTest
{
    public class Bowling
    {
        public List<Frame> Frames = new List<Frame>();
        private int _framesCount;
        private bool _isFirstBall;
        private bool _isFrameBonus;
        private int _tempTotalScore;
        private bool _youHaveNoChance;

        public Bowling()
        {
            _framesCount++;
            for (int i = 0; i < 10; i++)
            {
                Frames.Add(new Frame());
            }
        }

        public int CurrentFrameIndex => _framesCount - 1;
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

        public int Score()
        {
            return UpdateTotalScore();
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
        }

        private void FrameBonusProcess()
        {
            if (_isFrameBonus)
            {
                _framesCount--;
                Frames[CurrentFrameIndex].IsCompleted = false;
            }
        }

        private void FrameCompleted()
        {
            Frames[CurrentFrameIndex].IsCompleted = true;
        }

        private bool FrameUnCompleted()
        {
            return !Frames[CurrentFrameIndex].IsCompleted;
        }

        private bool HaveBonusChance()
        {
            return Frames.Any(x => x.SpireBonusTimes > 0 || x.StrikeBonusTimes > 0);
        }

        private void IsReachTheUpperLimit()
        {
            if (CurrentFrameIndex >= 10 && HaveBonusChance())
            {
                _isFrameBonus = true;
            }
            else if (CurrentFrameIndex >= 10 && NoBonusChance())
            {
                _youHaveNoChance = true;
            }
        }

        private bool IsSpire()
        {
            return _tempTotalScore == 10 && !_isFirstBall;
        }

        private bool IsStrike()
        {
            return _tempTotalScore == 10 && _isFirstBall;
        }

        private bool NoBonusChance()
        {
            return Frames.Any(x => x.SpireBonusTimes == 0 && x.StrikeBonusTimes == 0);
        }

        private void SetUpCounter()
        {
            _isFirstBall = !_isFirstBall || _isFrameBonus;
        }

        private void SetUpScoreIntoCurrentFrame()
        {
            if (!FrameUnCompleted())
            {
                Frames[CurrentFrameIndex].Score += _tempTotalScore;
            }
        }

        private void SpireBonusActivation()
        {
            if (IsSpire() && !_isFrameBonus)
            {
                Frames[CurrentFrameIndex].SpireBonusTimes++;
            }
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

        private void StrikeBonusActivation()
        {
            if (IsStrike() && !_isFrameBonus)
            {
                Frames[CurrentFrameIndex].StrikeBonusTimes += 2;
                _isFirstBall = _isFrameBonus;
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
        private int UpdateTotalScore()
        {
            return Frames.Sum(x => x.Score);
        }
    }

    public class Frame
    {
        public bool IsCompleted;
        public int Score;
        public int SpireBonusTimes { get; set; }
        public int StrikeBonusTimes { get; set; }
    }
}