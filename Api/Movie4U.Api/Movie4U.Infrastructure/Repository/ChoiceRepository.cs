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
    public class ChoiceRepository: IChoiceRepository
    {
        private readonly Movie4UDbContext _choiceDbContext;
        public ChoiceRepository(Movie4UDbContext choiceDbContext)
        {
            _choiceDbContext = choiceDbContext;
        }

        public async Task<Choice> GetByIdChoice(int id)
        {
            return await _choiceDbContext.Choice.Include(x => x.Genres).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Choice entity)
        {

            _choiceDbContext.Choice.Remove(entity);
            _choiceDbContext.SaveChanges();
        }

        public void UpdateRange(ICollection<Choice> entity)
        {

            _choiceDbContext.Choice.UpdateRange(entity);
            _choiceDbContext.SaveChanges();

            
        }

        public async Task<Choice> AddAsync(Choice entity)
        {

             await _choiceDbContext.Choice.AddAsync(entity);
            await _choiceDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _choiceDbContext.SaveChangesAsync();
        }

        public async Task<Choice> UpdateAsync(Choice entity)
        {

            Choice updated = _choiceDbContext.Choice.Update(entity).Entity;
            await _choiceDbContext.SaveChangesAsync();
            return updated;
        }
    }
}
