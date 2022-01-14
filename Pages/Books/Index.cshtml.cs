using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deak_Levente_Ferenc_Lab9.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Deak_Levente_Ferenc_Lab9.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Data.Deak_Levente_Ferenc_Lab9Context _context;

        public IndexModel(Data.Deak_Levente_Ferenc_Lab9Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }
        public BookData BookD { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();

            BookD.Books = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            if (id != null)
            {
                BookId = id.Value;
                var book = BookD.Books.Single(i => i.Id == id.Value);
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
        }
    }
}
