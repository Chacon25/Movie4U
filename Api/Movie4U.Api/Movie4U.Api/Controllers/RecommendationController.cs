using Microsoft.AspNetCore.Mvc;
using Movie4U.Core.Entities;
using Movie4U.Core.Enum;
using Movie4U.Core.Interfaces;
using Movie4U.Core.Models;
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
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<Genre>>> Get( int id)
        {

            var ServiceResult = await _genreService.GetbyId(id);
            if (ServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(ServiceResult.Error);

            return Ok(ServiceResult.Result);
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<Genre>>> Post([FromBody] ICollection<MovieChoice> data)
        {

            var ServiceResult = await _genreService.SendData(data);
            if (ServiceResult.ResponseCode != ResponseCode.Success)
                return BadRequest(ServiceResult.Error);

            return Ok(ServiceResult.Result);
        }

    }
}
