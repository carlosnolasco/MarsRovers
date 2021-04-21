using MarsRovers.Classes;
using MarsRovers.Interfaces;
using MarsRovers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRovers.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Process (SettingsModel data)
        {
            List<MarsRover> marsRoverResults = new List<MarsRover>();

            // Iterate all of the Rovers from the payload
            foreach(var item in data.MarsRovers)
            {
                // Create a new instance of the MarsRover based on the view model
                MarsRover marsRover = new MarsRover(item, data.Grid);
                
                // Filter the command list
                var instructions = Regex.Replace(item.Instructions, "/[^LRM]+/gi", "").ToCharArray();

                // Iterate each command in the command list
                foreach(char instruction in instructions)
                {
                    // Perform the command and stop iteration if Rover gets out of the bounds
                    if (!marsRover.PerformInstruction(instruction)) break;
                }

                // Add the Rover to result list
                marsRoverResults.Add(marsRover);
            }

            return Json(marsRoverResults);
        }
    }
}
