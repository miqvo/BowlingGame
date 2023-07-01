﻿using System;
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

            int pinsKnocked = frame.Roll();

            Console.WriteLine($"Frame: {CurrentFrame} | Roll: {frame.CurrentRoll} | Knocked Pins: {pinsKnocked} | Total Score: {TotalScore()}");
        }

        public bool IsDone()
        {
            return _frames.Count == 10 && _frames.Last().IsDone();
        }

        public int TotalScore()
        {
            int score = 0;

            if (_frames.Count == 1)
            {
                return _frames[0].GetScore();
            }
            for (int i = 0; i < _frames.Count; i++)
            {
                // Check if there are enough remaining frames to calculate the score

                score += _frames[i].GetTotalScore(_frames.GetRange(i + 1, _frames.Count - i - 1));

            }
            return score;
        }
    }
}
