using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheOnlineBookStore.Models
{
    public class Author : IEntityBase
    {
        [Key]

        public int Id { get; set; }
        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Picture is required")]
        public string PictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string Name { get; set; }
        [Display(Name = "About")]
        [Required(ErrorMessage = "About information for author is required")]
        public string About { get; set; }


        public List<AuthorsAndBooks> Books { get; set; }
    }
}
