using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie4U.Api.Models
{
    public class Data : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
