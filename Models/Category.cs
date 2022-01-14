using System.Collections.Generic;

namespace Deak_Levente_Ferenc_Lab9.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
