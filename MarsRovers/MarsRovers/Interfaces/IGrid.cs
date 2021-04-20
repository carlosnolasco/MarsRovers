using MarsRovers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Interfaces
{
    public interface IGrid
    {
        IList<MarsRover> MarsRovers { get; set; }
        int LimitX { get; set; }
        int LimitY { get; set; }
        bool MoveRoverForward(int id);
        void RotateRover(int id, char direction);
    }
}
