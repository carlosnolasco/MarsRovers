using MarsRovers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Classes
{
    public class MarsRover : IMarsRover
    {
        public MarsRover()
        {
            Status = true;
        }
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char Z { get; set; }
        public string Instructions { get; set; }
        public bool Status { get; set; }
    }
}
