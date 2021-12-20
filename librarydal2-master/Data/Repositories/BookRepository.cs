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
    public class BookRepository : IBookRepository
    {
        private LibraryDbContext _libraryDbContext;

        public BookRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task AddAsync(Book entity)
        {
            await _libraryDbContext.AddAsync(entity);
        }

        public void Delete(Book entity)
        {
            var item = _libraryDbContext.Books.Find(entity.Id);
            var result = item != null;
            if (result)
            {
                _libraryDbContext.Books.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            var item = await _libraryDbContext.Books.FindAsync(id);
            var result = item != null;
            if (result)
            {
                _libraryDbContext.Books
                    .Remove(_libraryDbContext.Books
                    .FirstOrDefault(x => x.Id == id));
            }
        }

        public IQueryable<Book> FindAll()
        {
            return _libraryDbContext.Set<Book>();
        }

        public IQueryable<Book> FindAllWithDetails()
        {
            return _libraryDbContext.Set<Book>().Include(x => x.Cards);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _libraryDbContext.Books.FindAsync(id);
        }

        public async Task<Book> GetByIdWithDetailsAsync(int id)
        {
            return await _libraryDbContext.Books
                .Include(x => x.Cards)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Book entity)
        {
            _libraryDbContext.Set<Book>().Update(entity);
        }
    }
}
