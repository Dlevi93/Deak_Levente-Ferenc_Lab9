using System.Collections.Generic;
using System.Threading.Tasks;
using Deak_Levente_Ferenc_Lab9.Data;
using Deak_Levente_Ferenc_Lab9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Deak_Levente_Ferenc_Lab9.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Deak_Levente_Ferenc_Lab9Context _context;

        public CreateModel(Deak_Levente_Ferenc_Lab9Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherId"] = new SelectList(_context.Set<Publisher>(), "Id", "PublisherName");

            var book = new Book
            {
                BookCategories = new List<BookCategory>()
            };
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryId = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }

            if (await TryUpdateModelAsync(newBook, "Book", i => i.Title, i => i.Author, i => i.Price, i => i.PublishingDate, i => i.PublisherId))
            {
                _context.Book.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }
    }
}
