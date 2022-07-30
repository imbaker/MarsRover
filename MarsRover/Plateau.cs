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
        private Orientation orientation;

        public enum Orientation : byte
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3
        }

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

        public void SetDirection(Orientation orientation)
        {
            var x = (int) orientation;
            var min = Enum.GetValues<Orientation>().Cast<byte>().Min();
            var max = Enum.GetValues<Orientation>().Cast<byte>().Max();
            if (x == byte.MaxValue)
                this.orientation = Orientation.West;
            else  if (x > max) 
                this.orientation = Orientation.North;
            else
                this.orientation = orientation;
        }

        public Orientation GetDirection()
        {
            return this.orientation;
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
                case Orientation.North:
                    this.MoveNorth();
                    break;
                case Orientation.East:
                    this.MoveEast();
                    break;
                case Orientation.South:
                    this.MoveSouth();
                    break;
                case Orientation.West:
                    this.MoveWest();
                    break;
            }
        }

        public void Right()
        {
            var orientation = this.GetDirection();
            this.SetDirection(orientation+1);
        }

        public void Left()
        {
            var orientation = this.GetDirection();
            this.SetDirection(orientation-1);
        }
    }
}
