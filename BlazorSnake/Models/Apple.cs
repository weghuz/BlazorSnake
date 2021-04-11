using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSnake.Models
{
    public class Apple
    {
        public Position pos { get; set; } = new Position();
        public Apple(Random rand)
        {
            pos.X = rand.Next(1, 20);
            pos.Y = rand.Next(1, 20);
        }
    }
}
