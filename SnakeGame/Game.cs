using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SnakeGame
{
    public class Game
    {
        public bool IsRunning { get; set; } = false;


        public ConsoleKey LastDirection { get; set; } = ConsoleKey.RightArrow;

        public List<(int, int)> BodyCoordinates { get; set; } = new List<(int, int)>();

        public int HeadX { get; set; } = 5;
        public int HeadY { get; set; } = 5;

        public int FoodX { get; set; } = 10;
        public int FoodY { get; set; } = 10;

        public Game()
        {
            Console.CursorVisible = false;

        }

        public void StartGame()
        {

            BodyCoordinates.Add((5, 4));
            BodyCoordinates.Add((5, 3));
            BodyCoordinates.Add((5, 2));

            IsRunning = true;

            while (IsRunning)
            {
                



                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:


                            LastDirection = key.Key;
                            break;
                        case ConsoleKey.UpArrow:

                            LastDirection = key.Key;
                            break;
                        case ConsoleKey.RightArrow:

                            LastDirection = key.Key;
                            break;
                        case ConsoleKey.DownArrow:

                            LastDirection = key.Key;
                            break;

                        default:
                            break;
                    }
                }
                var lastPos = BodyCoordinates.LastOrDefault();




                List<(int, int)> tempCoordinates = new List<(int, int)>();

                for (int i = 0; i < BodyCoordinates.Count; i++)
                {
                    (int, int) pos = BodyCoordinates[i];

                    int x = pos.Item1;
                    int y = pos.Item2;

                    if (i == 0)
                    {
                        tempCoordinates.Add((HeadX, HeadY));

                    }
                    else
                    {

                        tempCoordinates.Add(BodyCoordinates[i - 1]);
                    }


                }
                BodyCoordinates = tempCoordinates;
                switch (LastDirection)
                {

                    case ConsoleKey.LeftArrow:
                        HeadX = HeadX - 1;
                        break;
                    case ConsoleKey.UpArrow:
                        HeadY = HeadY - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        HeadX = HeadX + 1;
                        break;
                    case ConsoleKey.DownArrow:
                        HeadY = HeadY + 1;
                        break;
                }

                if (HeadX == FoodX && HeadY == FoodY)
                {
                    BodyCoordinates.Add(lastPos);


                    CreateFood();




                }


                Thread.Sleep(250);
                Render();
             
            }




        }
        private void Render()
        {
            Console.Clear();

            Console.SetCursorPosition(HeadX, HeadY);
            Console.Write($"0");

            foreach ((int, int) item in BodyCoordinates)
            {
                int x = item.Item1;
                int y = item.Item2;
                Console.SetCursorPosition(x, y);
                Console.Write($"#");
            }

            Console.SetCursorPosition(FoodX, FoodY);
            Console.Write($"+");


        }


        public void CreateFood()
        {
            Random rand = new Random();


            int ww = Console.WindowWidth;


            int wh = Console.WindowHeight;

            FoodX = rand.Next(0, ww);
            FoodY = rand.Next(0, wh);



        }






    }
}
