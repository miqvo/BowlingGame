using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{

    public class BowlingGame
    {
        private List<Frame> _frames = new();
        public int CurrentFrame => _frames.Count;

        public BowlingGame()
        {
            _frames.Add(new Frame(false));
        }

        public void Play()
        {
            Frame frame = _frames.Last();

            if (frame.IsDone())
            {
                frame = new Frame(_frames.Count == 10);
                _frames.Add(frame);
            }

            frame.Roll();

            Console.WriteLine($"Frame: {CurrentFrame} | Roll: {frame.CurrentRoll} | Knocked Pins: {frame.GetScore()} | Total Score: {TotalScore()}");
        }

        public bool IsDone()
        {
            return _frames.Count == 10 && _frames.Last().IsDone();
        }

        public int TotalScore()
        {
            return _frames.Sum(x => x.GetScore());
        }
    }
}
