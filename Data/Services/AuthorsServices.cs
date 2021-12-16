using eTickets.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOnlineBookStore.Models;

namespace TheOnlineBookStore.Data.Services
{
    public class AuthorsService : EntityBaseRepository<Author>, IAuthorsService
    {
        public AuthorsService(DatabaseContext context) : base(context) { }
        //private readonly DatabaseContext _context;
        //public AuthorsService(DatabaseContext context)
        //{
        //    _context = context;
        //}
        //public async Task AddAsync(Author author)
        //{
        //    await _context.Authors.AddAsync(author);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var result = await _context.Authors.FirstOrDefaultAsync(n => n.Id == id);
        //    _context.Authors.Remove(result);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<Author>> GetAll()
        //{
        //    var result = await _context.Authors.ToListAsync();
        //    return result;
        //}

        //public async Task<Author> GetByIdAsync(int id)
        //{
        //    var result = await _context.Authors.FirstOrDefaultAsync(n => n.Id == id);
        //    return result;
        //}

        //public async Task<Author> UpdateAsync(int id, Author newAuthor)
        //{
        //    _context.Update(newAuthor);
        //    await _context.SaveChangesAsync();
        //    return newAuthor;
        //}
    }
}
