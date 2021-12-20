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
    public class CardRepository : ICardRepository
    {
        private LibraryDbContext _libraryDbContext;
        public CardRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        public async Task AddAsync(Card entity)
        {
            await _libraryDbContext.Cards.AddAsync(entity);
        }

        public void Delete(Card entity)
        {
            _libraryDbContext.Cards.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var item = await _libraryDbContext.Cards.FindAsync(id);
            var result = item != null;
            if(result)
            {
                _libraryDbContext.Cards.Remove(item);
            }
        }

        public IQueryable<Card> FindAll()
        {
            return _libraryDbContext.Set<Card>();
        }

        public IQueryable<Card> FindAllWithDetails()
        {
            return _libraryDbContext.Cards.Include(x => x.Books).Include(x => x.Reader);
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await _libraryDbContext.Cards.FindAsync(id);
        }

        public async Task<Card> GetByIdWithDetailsAsync(int id)
        {
            return await _libraryDbContext.Cards
                .Include(x => x.Books)
                .Include(x => x.Reader)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Card entity)
        {
            _libraryDbContext.Set<Card>().Update(entity);
        }
    }
}
