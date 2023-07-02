using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Frame
    {
        private int[] _rolls = new int[3];
        private int _rollIndex = 0;

        private bool _isLastFrame = false;

        //private int _score = 0;

        public int CurrentRoll => _rollIndex;


        public Frame(bool isLastFrame)
        {
            _isLastFrame = isLastFrame;
        }

        public int Roll()
        {
            Random rnd = new();
            int pinsRemaining = 10 - _rolls.Sum();


            // 10th roll with 2 strikes gives an additional roll
            if(_isLastFrame && _rollIndex == 2)
            {
                pinsRemaining = 10;
            }


            int knockedPins = 10;
            //int knockedPins = rnd.Next(0, pinsRemaining + 1);

            _rolls[_rollIndex++] = knockedPins;

            return knockedPins;

        }

        public bool IsStrike()
        {
            return _rolls[0] == 10;
        }

        public bool IsSpare()
        {
            return !IsStrike() && _rolls[0] + _rolls[1] == 10;
        }

        public bool IsDone()
        {
            if (_isLastFrame)
            {
                if(IsStrike() || IsSpare())
                {
                    return _rollIndex == 3;
                }

                return _rollIndex == 2;
            }

            return IsStrike() || _rollIndex >= 2;
        }

        public int GetScoreWithoutBonus()
        {
            return _rolls.Sum();
        }

        public int GetTotalScore(List<Frame> frames)
        {
            return _rolls.Sum() + GetBonus(frames);
        }


        private int GetBonus(List<Frame> frames)
        {
            if (!frames.Any())
            {
                return 0; // No bonus available
            }

            //if (frames.Last()._isLastFrame)
            //{
            //    if(IsStrike())
            //    {
            //        if (_rollIndex < 3)
            //            return 0;

            //        return _rolls[1] + _rolls[2];
            //    }

            //    if (IsSpare())
            //    {
            //        if (_rollIndex < 3)
            //            return 0;

            //        return _rolls[2];
            //    }

            //    return 0;
            //}

            if (IsStrike())
            {
                if (!frames[0].IsDone())
                {
                    return 0; // No bonus available yet
                }

                // If the first bonus roll is a strike, look in the next frame
                if (frames[0].IsStrike())
                {
                    // 9th frame strike only looks for the 2 rolls in the 10th frame
                    if (frames[0]._isLastFrame && frames[0]._rollIndex > 1)
                    {
                        return frames[0]._rolls[0] + frames[0]._rolls[1];
                    }


                    if (frames.Count < 2)
                    {
                        return 0; // No bonus available yet
                    }

                    return 10 + frames[1]._rolls[0];
                }

                return frames[0]._rolls.Sum();
            }

            if (IsSpare())
            {
                return frames[0]._rolls[0];
            }



            return 0;
        }
    }
}
