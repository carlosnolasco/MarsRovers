using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Interfaces
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
        char Z { get; set; }
    }
}
