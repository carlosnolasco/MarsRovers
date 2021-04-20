using MarsRovers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Classes
{
    public class Grid : IGrid
    {
        public IList<MarsRover> MarsRovers { get; set; }
        public int LimitX { get; set; }
        public int LimitY { get; set; }

        public bool MoveRoverForward(int id)
        {
            var marsRover = MarsRovers.FirstOrDefault(f => f.ID == id);
            
            switch (marsRover.Z)
            {
                case 'N': 
                    if (marsRover.Y + 1 <= LimitY) marsRover.Y += 1;
                    else marsRover.Status = false;
                    break;
                case 'E':
                    if (marsRover.X + 1 <= LimitX) marsRover.X += 1;
                    else marsRover.Status = false;
                    break;
                case 'S':
                    if (marsRover.Y - 1 <= LimitY) marsRover.Y -= 1;
                    else marsRover.Status = false;
                    break;
                case 'W':
                    if (marsRover.X - 1 <= LimitX) marsRover.X -= 1;
                    else marsRover.Status = false;
                    break;
            }
            return marsRover.Status;
        }

        public void RotateRover(int id, char direction)
        {
            var marsRover = MarsRovers.FirstOrDefault(f => f.ID == id);
            switch (marsRover.Z)
            {
                case 'N':
                    marsRover.Z = direction == 'L' ? 'W' : 'E';
                    break;
                case 'E':
                    marsRover.Z = direction == 'L' ? 'N' : 'S';
                    break;
                case 'S':
                    marsRover.Z = direction == 'L' ? 'E' : 'W';
                    break;
                case 'W':
                    marsRover.Z = direction == 'L' ? 'S' : 'N';
                    break;
            }
        }
    }
}
