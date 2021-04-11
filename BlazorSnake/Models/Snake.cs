using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSnake.Models
{
    public class Snake
    {
        public List<Position> Positions { get; set; }
        public int x { get => Positions.FirstOrDefault().X; set => Positions.FirstOrDefault().X = x; }
        public int y { get => Positions.FirstOrDefault().Y; set => Positions.FirstOrDefault().Y = y; }
        public Snake()
        {
            Positions = new List<Position>();
            Positions.Add(new Position { X = 10, Y = 10 });

        }
        public bool Alive()
        {
            int x = Positions.FirstOrDefault().X;
            int y = Positions.FirstOrDefault().Y;
            if (x < 0 || y < 0 || x> 19 || y > 19)
            {
                return false;
            }    
            for(int i = 4; i < Positions.Count(); i++)
            {
                if(Positions[i].X == x && Positions[i].Y == y)
                {
                    return false;
                }
            }
            return true;
        }
        public void Left()
        {
            List<Position> lastPositions = new List<Position>();
            Positions.ForEach(p => lastPositions.Add(new Position() { X = p.X, Y = p.Y }));
            Positions.First().X -= 1;
            for (int i = 1; i < Positions.Count(); i++)
            {
                Positions[i] = lastPositions[i-1];
            }
        }
        public void Right()
        {
            List<Position> lastPositions = new List<Position>();
            Positions.ForEach(p => lastPositions.Add(new Position() { X = p.X, Y = p.Y}));
            Positions.First().X += 1;
            for (int i = 1; i < Positions.Count(); i++)
            {
                Positions[i] = lastPositions[i - 1];
            }
        }
        public void Up()
        {
            List<Position> lastPositions = new List<Position>();
            Positions.ForEach(p => lastPositions.Add(new Position() { X = p.X, Y = p.Y }));
            Positions.First().Y -= 1;
            for (int i = 1; i < Positions.Count(); i++)
            {
                Positions[i] = lastPositions[i-1];
            }
        }
        public void Down()
        {
            List<Position> lastPositions = new List<Position>();
            Positions.ForEach(p => lastPositions.Add(new Position() { X = p.X, Y = p.Y }));
            Positions.First().Y += 1;
            for (int i = 1; i < Positions.Count(); i++)
            {
                Positions[i] = lastPositions[i - 1];
            }
        }
    }
}
