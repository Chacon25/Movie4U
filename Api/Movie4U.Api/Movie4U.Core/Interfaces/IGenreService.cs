using Movie4U.Core.Entities;
using Movie4U.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Interfaces
{
    public interface IGenreService
    {

        Task<ServiceResult<Genre>> GetbyId(int id);

        Task<ServiceResult<Genre>> SendData(MovieChoice data);
    }
}
