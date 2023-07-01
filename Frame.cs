using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Frame
    {
        private int[] _rolls = new int[2];
        private int _rollIndex = 0;

        private bool _isLastFrame = false;

        private int _score = 0;

        public int CurrentRoll => _rollIndex;


        public Frame(bool isLastFrame)
        {
            _isLastFrame = isLastFrame;
        }

        public void Roll()
        {
            Random rnd = new();
            int pinsRemaining = 10;

            // Check for second roll
            if (_score > 0)
                pinsRemaining = 10 - _score;


            int knockedPins = rnd.Next(0, pinsRemaining + 1);

            _rolls[_rollIndex++] = knockedPins;
            _score += knockedPins;

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
                return (IsStrike() || IsSpare()) && _rollIndex < 3;
            }

            return IsStrike() || _rollIndex >= 2;
        }

        public int GetScore()
        {
            return _score;
        }
    }
}
