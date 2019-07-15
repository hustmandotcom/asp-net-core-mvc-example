using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_core_mvc_example.Models;
using asp_net_core_mvc_example.Services;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_core_mvc_example.Controllers
{
    public class MatrixController : Controller
    {
        private readonly IMatrixCalculationService _matrixCalculationService;

        public MatrixController(IMatrixCalculationService matrixCalculationService)
        {
            _matrixCalculationService = matrixCalculationService;
        }

        public IActionResult Spiral()
        {
            var model = new SpiralMatrixModel();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Spiral(int numberForCalculation)
        {
            var model = new SpiralMatrixModel();
            model.NumberForCalculation = numberForCalculation;
            model.Matrix = _matrixCalculationService.Calculate(numberForCalculation);
            return View(model);
        }
    }
}