using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_core_mvc_example.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_core_mvc_example.Controllers
{
    public class NumberFormatterController : Controller
    {
        public IActionResult Spiral()
        {
            var model = new SpiralNumberFormatterModel();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Spiral(int numberForCalculation)
        {
            var model = new SpiralNumberFormatterModel();
            model.NumberForCalculation = numberForCalculation;
            return View(model);
        }
    }
}