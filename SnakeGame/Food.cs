using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Food
    {
        public Tuple<int, int> Position { get; private set; }
        private Random random;
        private int boardWidth;
        private int boardHeight;

        public Food(int width, int height)
        {
            random = new Random();
            boardWidth = width;
            boardHeight = height;
            GeneratePosition();
        }

        public void GeneratePosition()
        {
            int x = random.Next(1, boardWidth - 1);
            int y = random.Next(1, boardHeight - 1);
            Position = new Tuple<int, int>(x, y);
        }
    }

}
