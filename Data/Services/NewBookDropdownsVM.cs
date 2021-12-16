using System.Collections.Generic;
using TheOnlineBookStore.Models;

namespace TheOnlineBookStore.Data.Services
{
    public class NewBookDropdownsVM
    {
        public NewBookDropdownsVM()
        {
            Publishers = new List<Publisher>();
            Authors = new List<Author>();
        }

        public List<Publisher> Publishers { get; set; }
        public List<Author> Authors { get; set; }
    }
}