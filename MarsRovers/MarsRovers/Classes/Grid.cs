﻿using MarsRovers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Classes
{
    public class Grid : IGrid
    {
        public int LimitX { get; set; }
        public int LimitY { get; set; }
    }
}
