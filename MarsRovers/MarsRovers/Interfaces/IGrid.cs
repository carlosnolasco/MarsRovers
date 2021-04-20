using MarsRovers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Interfaces
{
    public interface IGrid
    {
        int LimitX { get; set; }
        int LimitY { get; set; }
    }
}
