using Microsoft.AspNetCore.Mvc;
using Movie4U.Core.Entities;
using Movie4U.Core.Enum;
using Movie4U.Core.Interfaces;
using Movie4U.Core.Models;
using Movie4U.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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


        [HttpGet]
        [Route("userid")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie(string userid)
        {
            string result;
            using (var request = new HttpClient())
            {
                result = await request.GetStringAsync($"https://api.themoviedb.org/3/discover/movie?api_key=03fdd8f321f29b9e3f052238c9a26c14&with_genres={userid}");
            }
            var movies = JsonConvert.DeserializeObject<Results>(result);

            return Ok(movies);
        }


        //[HttpPost]

        //public async Task<ActionResult> SendEmail([FromBody] EmailDto email)
        //{

        //   var emailService = new EmailService();
        //    await emailService.SendEmails(email.Email);

        //    return Ok();
        //}



    }
    public class EmailDto
    {
    public string Email { get; set; }
    }
}
