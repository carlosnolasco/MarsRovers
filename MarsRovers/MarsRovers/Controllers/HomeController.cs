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
            foreach(var item in data.MarsRovers)
            {
                MarsRover marsRover = new MarsRover(item, data.Grid);

                var instructions = Regex.Replace(item.Instructions, "/[^LRM]+/gi", "").ToCharArray();

                foreach(char instruction in instructions)
                {
                    if (!marsRover.ProcessInstruction(instruction)) break;
                }
                marsRoverResults.Add(marsRover);
            }

            return Json(marsRoverResults);
        }
    }
}
