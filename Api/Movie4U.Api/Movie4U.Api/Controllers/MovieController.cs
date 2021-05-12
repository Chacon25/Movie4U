using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie4U.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {

        private readonly IMovieService _IMovieService;

        public IActionResult Index()
        {
            return View();
        }
    }
}
