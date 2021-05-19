using Microsoft.AspNetCore.Mvc;
using Movie4U.Core.Entities;
using Movie4U.Core.Enum;
using Movie4U.Core.Interfaces;
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

        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> Get()
        {

            var ServiceResult = await _movieService.GetAll();
            if (ServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(ServiceResult.Error);

            return Ok(ServiceResult.Result);
        }

    }
}
