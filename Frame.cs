namespace Bowling
{
    public class Frame
    {
        private readonly int[] _rolls = new int[3];
        private int _rollIndex = 0;

        private readonly bool _isLastFrame = false;

        public int CurrentRoll => _rollIndex;


        public Frame(bool isLastFrame)
        {
            _isLastFrame = isLastFrame;
        }

        public int Roll()
        {
            Random rnd = new();
            int pinsRemaining = 10 - _rolls.Sum();

            // 10th roll with a strike gives an additional roll
            if (_isLastFrame && _rollIndex == 2)
            {
                pinsRemaining = 10;
            }

            int knockedPins = rnd.Next(0, pinsRemaining + 1);

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
            // 10th frame case
            if (_isLastFrame)
            {
                if (IsStrike() || IsSpare())
                {
                    return _rollIndex == 3;
                }

                return _rollIndex == 2;
            }

            // 1st to 9th frame case
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
