using MarsRovers.Classes;
using MarsRovers.Interfaces;
using MarsRovers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public JsonResult Process ([FromBody]Grid data)
        {
            List<MarsRover> marsRoverResults = new List<MarsRover>();
            foreach(var item in data.MarsRovers)
            {
                foreach(char instruction in item.Instructions.ToCharArray())
                {
                    if (instruction == 'M')
                    {
                        if (!data.MoveRoverForward(item.ID)) break;
                    }
                    else
                    {
                        data.RotateRover(item.ID, instruction);
                    }
                }
                marsRoverResults.Add(item);
            }

            return Json(marsRoverResults);
        }
    }
}
