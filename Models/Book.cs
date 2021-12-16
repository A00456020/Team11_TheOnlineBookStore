using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TheOnlineBookStore.Data;

namespace TheOnlineBookStore.Models
{
    public class Book:IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public double Price { get; set; }
        public string CoverURL { get; set; }
        public int UnitsSold { get; set; }
        public int UnitsAvailable { get; set; }
        public BookGenre Genre { get; set; }

        public int PublisherID { get; set; }
        [ForeignKey("PublisherID")]
        public Publisher Publisher { get; set; }

        public List<AuthorsAndBooks> Authors { get; set; }
    }
}
