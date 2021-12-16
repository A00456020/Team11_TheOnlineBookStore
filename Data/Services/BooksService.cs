using eTickets.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOnlineBookStore.Models;

namespace TheOnlineBookStore.Data.Services
{
    public class BooksService:EntityBaseRepository<Book>, IBooksService
    {
        private readonly DatabaseContext _context;
        public BooksService(DatabaseContext context):base(context)
        {
            _context = context;
        }

        public async Task AddNewBookAsync(NewBookVM data)
        {
            var newBook = new Book()
            {
                Name = data.Name,
                About = data.About,
                Price = data.Price,
                CoverURL = data.CoverURL,
                Genre = data.BookGenre,
                PublisherID = data.PublisherId
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var authorId in data.AuthorIds)
            {
                var newAuthorBook = new AuthorsAndBooks()
                {
                    BookID = newBook.Id,
                    AuthorID = authorId
                };
                await _context.Authors_Books.AddAsync(newAuthorBook);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                .Include(p => p.Publisher)
                .Include(am => am.Authors).ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(n => n.Id == id);

            return bookDetails;
        }

        public async Task<Book> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Books
                .Include(p => p.Publisher)
                .Include(am => am.Authors).ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewBookDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewBookDropdownsVM()
            {
                Authors = await _context.Authors.OrderBy(n => n.Name).ToListAsync(),
                Publishers = await _context.Publishers.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateBookAsync(NewBookVM data)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbBook != null)
            {
                dbBook.Name = data.Name;
                dbBook.About = data.About;
                dbBook.Price = data.Price;
                dbBook.CoverURL = data.CoverURL;
                dbBook.Genre = data.BookGenre;
                dbBook.PublisherID = data.PublisherId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingAuthorsDb = _context.Authors_Books.Where(n => n.BookID == data.Id).ToList();
            _context.Authors_Books.RemoveRange(existingAuthorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var authorId in data.AuthorIds)
            {
                var newActorMovie = new AuthorsAndBooks()
                {
                    BookID = data.Id,
                    AuthorID = authorId
                };
                await _context.Authors_Books.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        Task<NewBookDropdownsVM> IBooksService.GetNewBookDropdownsValues()
        {
            throw new NotImplementedException();
        }
    }
}
