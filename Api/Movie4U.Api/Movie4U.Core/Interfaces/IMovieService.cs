using Movie4U.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Interfaces
{
    public interface IMovieService
    {

        Task<ServiceResult<IEnumerable<Movie>>> GetAll();

      
    }
}
