using MarsRovers.Interfaces;
using MarsRovers.Models;

namespace MarsRovers.Classes
{
    public class MarsRover : Vehicle
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
    }
}
