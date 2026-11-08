using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ulici_Denisa_Lab2.Models;

namespace Ulici_Denisa_Lab2.Pages.BorrowingPages;

public class DetailsModel : PageModel
{
    private readonly Ulici_Denisa_Lab2Context _context;
    public DetailsModel(Ulici_Denisa_Lab2Context context)
    {
        _context = context;
    }

    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing
            .Include(b => b.Member)
            .Include(b => b.Book)
            .ThenInclude(b => b.Author)
            .FirstOrDefaultAsync(m => m.ID == id);
        if (borrowing is null)
        {
            return NotFound();
        }
        
        Borrowing = borrowing;
        return Page();
    }
}
