using MarsRovers.Classes;
using MarsRovers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Models
{
    public class SettingsModel
    {
        public Grid Grid { get; set; }
        public List<MarsRoverModel> MarsRovers { get; set; }
    }
}
