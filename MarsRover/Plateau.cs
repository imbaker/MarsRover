using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Plateau
    {
        private int currentX;
        private int currentY;
        private string heading;

        public Plateau(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x { get; set; }
        public int y { get; set; }

        public void SetPosition(int x, int y)
        {
            this.currentX = x;
            this.currentY = y;
        }

        public (int x, int y) GetPosition()
        {
            return (currentX, currentY);
        }

        public void SetDirection(string heading)
        {
            this.heading = heading;
        }

        public string GetDirection()
        {
            return this.heading;
        }

        public void MoveNorth()
        {
            if (this.currentY < this.y)
                this.currentY++;
        }

        public void MoveEast()
        {
            if (this.currentX < this.x)
                this.currentX++;
        }

        public void MoveSouth() 
        { 
            if (this.currentY > 0)
                this.currentY--; 
        }

        public void MoveWest() 
        { 
            if (this.currentX > 0)
                this.currentX--; 
        }

        public void Move()
        {
            switch (this.GetDirection())
            {
                case "N":
                    this.MoveNorth();
                    break;
                case "E":
                    this.MoveEast();
                    break;
                case "S":
                    this.MoveSouth();
                    break;
                case "W":
                    this.MoveWest();
                    break;
            }
        }

        public void Right()
        {
            switch (this.GetDirection())
            {
                case "N":
                    this.SetDirection("E");
                    break;
                case "E":
                    this.SetDirection("S");
                    break;
                case "S":
                    this.SetDirection("W");
                    break;
                case "W":
                    this.SetDirection("N");
                    break;
            }
        }

        public void Left()
        {
            switch (this.GetDirection())
            {
                case "N":
                    this.SetDirection("W");
                    break;
                case "E":
                    this.SetDirection("N");
                    break;
                case "S":
                    this.SetDirection("E");
                    break;
                case "W":
                    this.SetDirection("S");
                    break;
            }
        }
    }
}
