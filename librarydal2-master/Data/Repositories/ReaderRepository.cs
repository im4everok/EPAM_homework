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
    public class ReaderRepository : IReaderRepository
    {
        private LibraryDbContext _libraryDbContext;
        public ReaderRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task AddAsync(Reader entity)
        {
            await _libraryDbContext.Readers.AddAsync(entity);
        }

        public void Delete(Reader entity)
        {
            var item = _libraryDbContext.Readers.FirstOrDefault(x => x.Id == entity.Id);
            var result = item != null;
            if (result)
            {
                _libraryDbContext.Readers.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var item = await _libraryDbContext.Readers.FindAsync(id);
            var result = item != null;
            if (result)
            {
                _libraryDbContext.Readers.Remove(item);
            }
        }

        public IQueryable<Reader> FindAll()
        {
            return _libraryDbContext.Set<Reader>();
        }

        public IQueryable<Reader> GetAllWithDetails()
        {
            return FindAll()
                .Include(x => x.Cards)
                .Include(x => x.ReaderProfile);
        }

        public async Task<Reader> GetByIdAsync(int id)
        {
            return await _libraryDbContext.Readers.FindAsync(id);
        }

        public async Task<Reader> GetByIdWithDetails(int id)
        {
            return await _libraryDbContext.Readers
                .Include(x => x.ReaderProfile)
                .Include(x => x.Cards)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Reader entity)
        {
            _libraryDbContext.Set<Reader>().Update(entity);
        }
    }
}
