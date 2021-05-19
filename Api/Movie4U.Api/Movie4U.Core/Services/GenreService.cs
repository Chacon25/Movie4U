using Movie4U.Core.Entities;
using Movie4U.Core.Interfaces;
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
        public GenreService(IGenreRepository genreService)
        {
            _genreService = genreService;
        }
        public async Task<ServiceResult<Genre>> GetbyId(int id)
        {
            var result = await _genreService.GetById(id);

            return ServiceResult<Genre>.SuccessResult(result);
        }
    }
}
