using System.Collections.Generic;
using System.Threading.Tasks;
using Deak_Levente_Ferenc_Lab9.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Deak_Levente_Ferenc_Lab9.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Data.Deak_Levente_Ferenc_Lab9Context _context;

        public IndexModel(Data.Deak_Levente_Ferenc_Lab9Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
