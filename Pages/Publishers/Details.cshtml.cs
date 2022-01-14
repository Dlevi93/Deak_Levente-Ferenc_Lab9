using System.Threading.Tasks;
using Deak_Levente_Ferenc_Lab9.Data;
using Deak_Levente_Ferenc_Lab9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Deak_Levente_Ferenc_Lab9.Pages.Publishers
{
    public class DetailsModel : PageModel
    {
        private readonly Deak_Levente_Ferenc_Lab9Context _context;

        public DetailsModel(Deak_Levente_Ferenc_Lab9Context context)
        {
            _context = context;
        }

        public Publisher Publisher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Publisher = await _context.Publisher.FirstOrDefaultAsync(m => m.Id == id);

            if (Publisher == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
