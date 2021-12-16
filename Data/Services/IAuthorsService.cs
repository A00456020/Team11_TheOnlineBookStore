using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOnlineBookStore.Models;

namespace TheOnlineBookStore.Data.Services
{
    public interface IAuthorsService:IEntityBaseRepository<Author>
    {
        //Task<IEnumerable<Author>> GetAll();
        //Task<Author> GetByIdAsync(int id);
        //Task AddAsync(Author author);
        //Task<Author> UpdateAsync(int id, Author newActor);

        //Task DeleteAsync(int id);
    }
}
