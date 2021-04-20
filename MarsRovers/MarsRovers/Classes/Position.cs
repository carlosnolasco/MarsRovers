using MarsRovers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Classes
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Z { get; set; }
    }
}
