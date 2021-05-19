using Movie4U.Core.Entities;
using Movie4U.Core.Interfaces;
using Movie4U.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreService;
        private readonly IMovieRepository _movieService;

        private readonly IRepository<Genre> _genrepository;
        private readonly IRepository<Movie> _moviepository;


        public GenreService(IGenreRepository genreService, IMovieRepository movieService, IRepository<Genre> genrepository, IRepository<Movie> moviepository)
        {
            _genreService = genreService;
            _movieService = movieService;
            _genrepository = genrepository;
            _moviepository = moviepository;
        }
        public async Task<ServiceResult<Genre>> GetbyId(int id)
        {
            var result = await _genreService.GetById(id);

            return ServiceResult<Genre>.SuccessResult(result);
        }

        public Task<ServiceResult<Genre>> SendData(MovieChoice data)
        {


            data.Id



            throw new NotImplementedException();
        }
    }
}
