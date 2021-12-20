using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private LibraryDbContext _libraryDbContext;
        public HistoryRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task AddAsync(History entity)
        {
            await _libraryDbContext.Histories.AddAsync(entity);
        }

        public void Delete(History entity)
        {
            _libraryDbContext.Histories.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var item = await _libraryDbContext.Histories.FindAsync(id);
            var result = item != null;
            if (result)
            {
                _libraryDbContext.Histories.Remove(item);
            }
        }

        public IQueryable<History> FindAll()
        {
            return _libraryDbContext.Set<History>();
        }

        public IQueryable<History> GetAllWithDetails()
        {
            return _libraryDbContext.Set<History>().Include(x => x.Card).Include(x => x.Book);
        }

        public async Task<History> GetByIdAsync(int id)
        {
            return await _libraryDbContext.Histories.FindAsync(id);
        }

        public void Update(History entity)
        {
            _libraryDbContext.Set<History>().Update(entity);
        }
    }
}
