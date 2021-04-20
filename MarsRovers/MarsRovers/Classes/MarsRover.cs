using MarsRovers.Interfaces;
using MarsRovers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Classes
{
    public class MarsRover : IMarsRover
    {
        public MarsRover() { }
        public MarsRover(MarsRoverModel model, IGrid grid)
        {
            InitialPosition = new Position { X = model.X, Y = model.Y, Z = model.Z };
            LastPosition = new Position { X = model.X, Y = model.Y, Z = model.Z };
            Instructions = model.Instructions;
            Grid = grid;
            Status = true;
        }
        public IGrid Grid { get; set; }
        public IPosition InitialPosition { get; set; }
        public IPosition LastPosition { get; set; }
        public string Instructions { get; set; }
        public bool Status { get; set; }

        public void MoveForward()
        {
            switch (LastPosition.Z)
            {
                case 'N':
                    if (LastPosition.Y + 1 <= Grid.LimitY) LastPosition.Y += 1;
                    else Status = false;
                    break;
                case 'E':
                    if (LastPosition.X + 1 <= Grid.LimitX) LastPosition.X += 1;
                    else Status = false;
                    break;
                case 'S':
                    if (LastPosition.Y - 1 >= 0) LastPosition.Y -= 1;
                    else Status = false;
                    break;
                case 'W':
                    if (LastPosition.X - 1 >= 0) LastPosition.X -= 1;
                    else Status = false;
                    break;
            }
        }

        public void Rotate(char direction)
        {
            switch (LastPosition.Z)
            {
                case 'N':
                    LastPosition.Z = direction == 'L' ? 'W' : 'E';
                    break;
                case 'E':
                    LastPosition.Z = direction == 'L' ? 'N' : 'S';
                    break;
                case 'S':
                    LastPosition.Z = direction == 'L' ? 'E' : 'W';
                    break;
                case 'W':
                    LastPosition.Z = direction == 'L' ? 'S' : 'N';
                    break;
                default:
                    Status = false;
                    break;
            }
        }

        public bool ProcessInstruction(char instruction)
        {
            switch(instruction)
            {
                case 'M':
                    MoveForward();
                    break;
                case 'L':
                case 'R':
                    Rotate(instruction);
                    break;
                default:
                    Status = false;
                    break;

            }
            return Status;
        }
    }
}
