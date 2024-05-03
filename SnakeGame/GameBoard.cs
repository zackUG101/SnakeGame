using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class GameBoard
    {
        public int Width { get; }
        public int Height { get; }
        private Snake snake;
        private Food food;
        private bool isGameOver;
        private int score;

        public GameBoard(int width, int height)
        {
            Width = width;
            Height = height;
            snake = new Snake(width / 2, height / 2);
            food = new Food(width, height);
            Console.SetWindowSize(Width, Height + 3); 
        }

        public void StartGame()
        {
            DisplayStartMessage();
            while (!isGameOver)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    ChangeDirection(key);
                }

                ProcessMovement();

                Draw();
                Thread.Sleep(100);
            }

            GameOver();
        }

        private void GameOver()
        {
            Console.SetCursorPosition(0, Height + 2);
            Console.WriteLine("Game Over! Final Score: " + score);
            Console.ReadKey();
        }

        private void DisplayStartMessage()
        {
            Console.Clear();
            Console.WriteLine("Press ENTER to start the game...");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        private void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (snake.Direction != "DOWN") snake.Direction = "UP";
                    break;
                case ConsoleKey.DownArrow:
                    if (snake.Direction != "UP") snake.Direction = "DOWN";
                    break;
                case ConsoleKey.LeftArrow:
                    if (snake.Direction != "RIGHT") snake.Direction = "LEFT";
                    break;
                case ConsoleKey.RightArrow:
                    if (snake.Direction != "LEFT") snake.Direction = "RIGHT";
                    break;
            }
        }

        private void ProcessMovement()
        {
            var newHead = snake.GetNextHeadPosition();
            
            //If hit border
            if (newHead.Item1 < 0 || newHead.Item1 >= Width || newHead.Item2 < 0 || newHead.Item2 >= Height || snake.IsHitSelf(newHead))
            {
                isGameOver = true;
                return;
            }

            snake.Move(newHead);

            //Eat
            if (newHead.Equals(food.Position))
            {
                score += 10;  // Increase score by 10 points per food
                food.GeneratePosition();
            }
            else
            {
                snake.CutTail();
            }
        }

        private void Draw()
        {
            Console.Clear();
            //Draw Snake
            foreach (var segment in snake.Body)
            {
                Console.SetCursorPosition(segment.Item1, segment.Item2);
                Console.Write("■");
            }

            //Draw Food
            Console.SetCursorPosition(food.Position.Item1, food.Position.Item2);
            Console.Write("@");

            // Display score
            Console.SetCursorPosition(0, Height);
            Console.WriteLine("''''''''''''''''''''''''''''''''''''''''");
            Console.Write("Score: " + score);
        }

    }

}

