using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorSnake.Models;

namespace BlazorSnake.Pages
{
    public class SnakeGame : ComponentBase
    {
        public List<Pixel> screen = new List<Pixel>();
        public int Score { get; set; } = 0;
        public List<Score> scores;
        public Snake player;
        public Random rand = new Random();
        public Apple apple;
        private string bgColor = "pink";
        private string lastKeyDown;
        public SnakeGame()
        {
            scores = new List<Score>();
            player = new Snake();
            apple = new Apple(rand);
            for(int y = 0; y < 20; y++)
            {
                for(int x = 0; x < 20; x++)
                {
                    screen.Add(new Pixel() { pos = new Position() { X = x, Y = y }, color = bgColor });


                }
            }
        }

        public void Clear()
        {
            foreach(Pixel p in screen)
            {
                p.color = bgColor;
            }
        }

        public bool TestDirection(string direction)
        {
            if (direction == "d" || direction == "ArrowRight")
            {
                return (lastKeyDown != "a" && lastKeyDown != "ArrowLeft");
            }
            if (direction == "a" || direction == "ArrowLeft")
            {
                return (lastKeyDown != "d" && lastKeyDown != "ArrowRight");
            }
            if (direction == "s" || direction == "ArrowDown")
            {
                return (lastKeyDown != "w" && lastKeyDown != "ArrowUp");
            }
            if (direction == "w" || direction == "ArrowUp")
            {
                return (lastKeyDown != "s" && lastKeyDown != "ArrowDown");
            }
            return false;
        }

        public bool Update(string keyDown)
        {
            lastKeyDown = keyDown;

            if (lastKeyDown == "w" || lastKeyDown == "ArrowUp")
            {
                player.Up();
            }
            if (lastKeyDown == "s" || lastKeyDown == "ArrowDown")
            {
                player.Down();
            }
            if (lastKeyDown == "a" || lastKeyDown == "ArrowLeft")
            {
                player.Left();
            }
            if (lastKeyDown == "d" || lastKeyDown == "ArrowRight")
            {
                player.Right();
            }
            bool alive = player.Alive();
            if(alive)
            {
                Clear();
                foreach (Position p in player.Positions)
                {
                    UpdateColorAt(p.X, p.Y, "black");
                }
                if (apple.pos.X == player.x && apple.pos.Y == player.y)
                {
                    apple = new Apple(rand);
                    player.Positions.Add(new Position() { X = player.x, Y=player.y } );
                    Score += 1;
                }
                UpdateColorAt(apple.pos.X, apple.pos.Y, "red");
                base.StateHasChanged();
            }
            return (alive);
        }

        public void UpdateColorAt(int x, int y, string color)
        {
            if(screen.Where(p => p.pos.X == x && p.pos.Y == y).Count()>0)
            {
                screen.Where(p => p.pos.X == x && p.pos.Y == y).FirstOrDefault().color = color;
            }
        }
    }
}
