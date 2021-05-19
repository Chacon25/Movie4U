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
    public class GenreRepository : IGenreRepository
    {


        private readonly Movie4UDbContext _genreDbContext;
        public GenreRepository(Movie4UDbContext genreDbContext)
        {
            _genreDbContext = genreDbContext;
        }

     
        public Task<Genre> GetById(int id)
        {
            return (Task<Genre>)_genreDbContext.Genre.Where(x => x.Id == id);
        }
    }
        
}
