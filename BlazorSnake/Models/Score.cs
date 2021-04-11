using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSnake.Models
{
    public class Score
    {
        public string Name { get; set; } = "";
        public int Points { get; set; } = 0;
        public Score(string name, int score)
        {
            Name = name;
            Points = score;
        }
    }
}
