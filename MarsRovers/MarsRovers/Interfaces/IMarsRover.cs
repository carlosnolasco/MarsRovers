using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Interfaces
{
    public interface IMarsRover
    {
        IGrid Grid { get; set; }
        IPosition InitialPosition { get; set; }
        IPosition LastPosition { get; set; }
        string Instructions { get; set; }
        bool Status { get; set; }
        public void MoveForward();
        public void Rotate(char direction);
    }
}
