using Movie4U.Core.Entities;
using Movie4U.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Services
{
    public class MovieService : IMovieService
    {

        private readonly IMovieRepository _movieService;
        private readonly IGenreRepository _GenreService;

        public MovieService(IMovieRepository movieService)
        {
            _movieService = movieService;
        }

        public async Task<ServiceResult<IEnumerable<Movie>>> GetAll()
        {
            var result = await _movieService.FillterAll();
            return ServiceResult<IEnumerable<Movie>>.SuccessResult(result);
        }

        public Task<ServiceResult<IEnumerable<Genre>>> GetbyId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
