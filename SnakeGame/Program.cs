using System;

namespace SnakeGame
{
    class Program
    {
        public static Game Snaaaake { get; set; }
        static void Main(string[] args)
        {
            Snaaaake = new Game();
          Snaaaake.StartGame();


        }
    }
}
