using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake: Figure
    {
        public Direction direction;

        public Snake(Point tail, int length, Direction _direction)
        {
            pList = new List<Point>();
            direction = _direction;
            for (int i = 0; i < length; i++ )
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        public void HandleKey(ConsoleKey Key)
        {
            
            if (Key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            if (Key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            if (Key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            if (Key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}
