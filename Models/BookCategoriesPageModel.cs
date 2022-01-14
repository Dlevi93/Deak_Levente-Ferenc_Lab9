using System.Collections.Generic;
using System.Linq;
using Deak_Levente_Ferenc_Lab9.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Deak_Levente_Ferenc_Lab9.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Deak_Levente_Ferenc_Lab9Context context,
            Book book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(
                book.BookCategories.Select(c => c.CategoryId));

            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryId = cat.Id,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.Id)
                });
            }
        }

        public void UpdateBookCategories(Deak_Levente_Ferenc_Lab9Context context,
            string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }

            var selectedCategoriesHs = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
                (bookToUpdate.BookCategories.Select(c => c.Category.Id));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHs.Contains(cat.Id.ToString()))
                {
                    if (!bookCategories.Contains(cat.Id))
                    {
                        bookToUpdate.BookCategories.Add(
                            new BookCategory
                            {
                                BookId = bookToUpdate.Id,
                                CategoryId = cat.Id
                            });
                    }
                }
                else
                {
                    if (!bookCategories.Contains(cat.Id)) continue;

                    var courseToRemove
                        = bookToUpdate
                            .BookCategories
                            .SingleOrDefault(i => i.CategoryId == cat.Id);
                    context.Remove(courseToRemove);
                }
            }
        }
    }
}
