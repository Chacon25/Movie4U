using Microsoft.EntityFrameworkCore;
using Movie4U.Core.Entities;
using Movie4U.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Infrastructure.Repository
{
    public class MovieRepository : IMovieRepository
    {

        private readonly Movie4UDbContext _movieDbContext;


        public MovieRepository(Movie4UDbContext movieDbContext)
        {
            _movieDbContext  = movieDbContext;
        }
        public async Task<IEnumerable<Movie>> FillterAll()
        {
            return await _movieDbContext.Movie.ToListAsync();
        }
    }
}
