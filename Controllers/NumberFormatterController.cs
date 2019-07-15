using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_core_mvc_example.Controllers
{
    public class NumberFormatterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}