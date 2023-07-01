using System;
using System.Collections.Generic;

namespace Bowling
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Press any key to play a game.");

            while (true)
            {
                Console.ReadKey(true);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Q)
                    {
                        break;
                    }
                }

                BowlingGame game = new BowlingGame();

                Console.WriteLine("Game started. Press any key to roll the ball.");

                while (!game.IsDone())
                {
                    Console.ReadKey(true);

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    }

                    game.Play();

                }
            }
        }
    }
}