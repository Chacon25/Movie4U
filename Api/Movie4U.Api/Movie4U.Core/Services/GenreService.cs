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

      
        private readonly IRepository<User> _userService;
        private readonly IChoiceRepository _choiceService;
  
        private readonly IMovieRepository _moviepository;


        public GenreService(IGenreRepository genreService, IMovieRepository movieService, IMovieRepository moviepository, IRepository<User> userService, IChoiceRepository choiceService)
        {
            _genreService = genreService;
            _movieService = movieService;
      
            _moviepository = moviepository;
            _userService = userService;
            _choiceService = choiceService;


        }
        public async Task<ServiceResult<Genre>> GetbyId(int id)
        {
            var result = await _genreService.GetById(id);

            return ServiceResult<Genre>.SuccessResult(result);
        }

        public async Task<ServiceResult<IEnumerable<Genre>>> SendData(ICollection<MovieChoice> data, UserDto user)
        {

            Movie tmpMovie = new Movie();
            Choice tmpChoice = new Choice();
            User tmpUser = new User();
            List<Genre> tmpGenres = new List<Genre>();
            List<Movie> movieExist = (List<Movie>)await _movieService.FillterAll();
            foreach (var item in data)
            {

                tmpMovie.Id = item.Id;
                tmpMovie.Name = item.Title;
                var isExist = movieExist.Exists(x => x.Id == tmpMovie.Id);
               
                foreach (var item2 in item.genre_ids)
                {

                    var result = await _genreService.GetById(item2);

                    tmpGenres.Add(result);
                    tmpMovie.Genres.Add(result) ;

                }
                if (!isExist)
                {
                    var deleteDuplicate = tmpMovie.Genres.GroupBy(x => x.Id).Select(x => x.First()).ToList();

                    tmpMovie.Genres = deleteDuplicate;
                    await _moviepository.AddAsync(tmpMovie);
                    tmpMovie = new Movie();

                }


            }
            List<Genre> uniqueGenra = tmpGenres.Distinct().ToList();
           
            List<User> userExist = (List<User>)_userService.GetAll();

            var isExistUser = userExist.Exists(x => x.Name == user.Name);
            if (!isExistUser)
            {
                tmpUser.Name = user.Name;
                tmpUser.User_Name = user.Nickname;
                tmpUser.Email = user.Email;
                _userService.Add(tmpUser);
                tmpChoice.UserId = tmpUser.Id;
                tmpChoice.Genres = uniqueGenra;
                await _choiceService.AddAsync(tmpChoice);
                _userService.SaveChanges();
            }
            else
            {
                User userId =  _userService.GetByName(user.Name);
               // Choice choiceId = await _choiceService.GetByIdChoice(userId.Id);
               // tmpChoice.Id = choiceId.Id;
               // uniqueGenra.AddRange(choiceId.Genres);
               ////_choiceService.Remove(tmpChoice);
                tmpChoice.UserId = userId.Id;
                tmpChoice.Genres = uniqueGenra;
                await _choiceService.AddAsync(tmpChoice);
              //  await _choiceService.SaveChangesAsync();

                //await _choiceService.UpdateAsync(tmpChoice);
            }

            return ServiceResult<IEnumerable<Genre>>.SuccessResult(uniqueGenra);
        }
    }
}
