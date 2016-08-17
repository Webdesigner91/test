using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {

            Horizontal line1 = new Horizontal(0, 20, 10, '#');
            line1.Drow();

            Vertical line2 = new Vertical(0, 10, 20, '#');
            line2.Drow();

            Point p = new Point(0, 2, '>');
            Snake snake = new Snake(p, 3, Direction.RIGHT);
            snake.Drow();
            //snake.Move();

            FoodCreator FoodCreator = new FoodCreator(10, 25, '$');
            Point food = FoodCreator.CreateFood();
            food.Draw();


            while (true)
            {
                if (snake.Eat(food))
                {
                    food = FoodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }    
                    Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            //Console.ReadLine();
        }
    }
}
