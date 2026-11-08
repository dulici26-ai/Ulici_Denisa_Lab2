using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ulici_Denisa_Lab2.Models;

namespace Ulici_Denisa_Lab2.Pages.MemberPages;

public class IndexModel : PageModel
{
    private readonly Ulici_Denisa_Lab2Context _context;

    public IndexModel(Ulici_Denisa_Lab2Context context)
    {
        _context = context;
    }

    public IList<Member> Member { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Member = await _context.Member.ToListAsync();
    }
}
