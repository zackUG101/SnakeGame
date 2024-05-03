using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Snake
    {
        public LinkedList<Tuple<int, int>> Body { get; private set; }
        public string Direction { get; set; }

        public Snake(int initialX, int initialY)
        {
            Body = new LinkedList<Tuple<int, int>>();
            Body.AddLast(new Tuple<int, int>(initialX, initialY));
            Direction = "UP";
        }

        public Tuple<int, int> GetNextHeadPosition()
        {
            Tuple<int, int> head = Body.First.Value;
            int newX = head.Item1, newY = head.Item2;
            switch (Direction)
            {
                case "UP":
                    newY--;
                    break;
                case "DOWN":
                    newY++;
                    break;
                case "LEFT":
                    newX--;
                    break;
                case "RIGHT":
                    newX++;
                    break;
            }
            return new Tuple<int, int>(newX, newY);
        }

        public void Move(Tuple<int, int> newHead)
        {
            Body.AddFirst(newHead);
        }

        public void CutTail()
        {
            Body.RemoveLast();
        }

        public bool IsHitSelf(Tuple<int, int> position)
        {
            var hits = Body.Find(position);
            return hits != null && hits.Next != null;
        }
    }

}
