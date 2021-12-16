using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheOnlineBookStore.Data.Services
{
    public class NewBookVM
    {

        public int Id { get; set; }

        [Display(Name = "Book name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Book description")]
        [Required(ErrorMessage = "Description is required")]
        public string About { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Cover URL")]
        [Required(ErrorMessage = "Cover URL is required")]
        public string CoverURL { get; set; }

        [Display(Name = "Select a genre")]
        [Required(ErrorMessage = "Book genre is required")]
        public BookGenre BookGenre { get; set; }

        //Relationships
        [Display(Name = "Select authors(s)")]
        [Required(ErrorMessage = "Movie auhors(s) is required")]
        public List<int> AuthorIds { get; set; }
        
        [Display(Name = "Select a publisher")]
        [Required(ErrorMessage = "publisher is required")]
        public int PublisherId { get; set; }

    }
}