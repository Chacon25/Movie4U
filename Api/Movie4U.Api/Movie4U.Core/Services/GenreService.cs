﻿using Movie4U.Core.Entities;
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

        private readonly IRepository<User> _userService;
        private readonly IRepository<Genre> _genrepository;
        private readonly IRepository<Movie> _moviepository;


        public GenreService(IGenreRepository genreService, IMovieRepository movieService, IRepository<Genre> genrepository, IRepository<Movie> moviepository, IRepository<User> userService)
        {
            _genreService = genreService;
            _movieService = movieService;
            _genrepository = genrepository;
            _moviepository = moviepository;
            _userService = userService;


        }
        public async Task<ServiceResult<Genre>> GetbyId(int id)
        {
            var result = await _genreService.GetById(id);

            return ServiceResult<Genre>.SuccessResult(result);
        }

        public async Task<ServiceResult<IEnumerable<Genre>>> SendData(ICollection<MovieChoice> data , UserDto user)
        {

            Movie tmpMovie = new Movie();
            User tmpUser = new User();

            List<Genre> tmpGenres = new List<Genre>();

            List<Movie> movieExist = (List<Movie>)await _movieService.FillterAll();

            

            List<User> userExist = (List<User>)_userService.GetAll();

            var isExistUser = userExist.Exists(x => x.Name == user.Name);
            if (!isExistUser)
            {
                _userService.Add(tmpMovie);
                _userService.SaveChanges();

            }

            foreach (var item in data)
            {

                tmpMovie.Id = item.Id;
                tmpMovie.Name = item.Title;
                var isExist = movieExist.Exists(x => x.Id == tmpMovie.Id);
                if (!isExist)
                {
                    _moviepository.Add(tmpMovie);
                    _moviepository.SaveChanges();

                }

                foreach (var item2 in item.genre_ids)
                {

                    var result = await _genreService.GetById(item2);

                    tmpGenres.Add(result);

                }

            }


         

          
            

          




            var uniqueGenra = tmpGenres.Distinct().ToList();


            return ServiceResult<IEnumerable<Genre>>.SuccessResult(uniqueGenra);
        }
    }
}
