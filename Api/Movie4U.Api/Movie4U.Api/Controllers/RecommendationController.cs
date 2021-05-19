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
    public class RecommendationController : Controller
    {

        private readonly IGenreService _genreService;

        public RecommendationController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> Get([FromBody] int id)
        {

            var ServiceResult = await _genreService.GetbyId(id);
            if (ServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(ServiceResult.Error);

            return Ok(ServiceResult.Result);
        }

    }
}
