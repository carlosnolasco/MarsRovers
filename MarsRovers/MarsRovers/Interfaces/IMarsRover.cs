using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Interfaces
{
    public interface IMarsRover
    {
        int ID { get; set; }
        int X { get; set; }
        int Y { get; set; }
        char Z { get; set; }
        string Instructions { get; set; }
        bool Status { get; set; }
    }
}
