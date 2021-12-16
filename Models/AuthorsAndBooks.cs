using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheOnlineBookStore.Models
{
    public class AuthorsAndBooks
    {
        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public Author Author { get; set; }
        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public Book Book { get; set; }
    }
}
