using Movie4U.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Interfaces
{
    public interface IChoiceRepository
    {
        Task<Choice> GetByIdChoice(int id);
        void Remove(Choice entity);
        void UpdateRange(ICollection<Choice> entity);
        Task<Choice> UpdateAsync(Choice entity);

         Task<Choice> AddAsync(Choice entity);
         Task<int> SaveChangesAsync();

    }
}
