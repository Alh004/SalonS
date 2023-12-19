using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SalonS.Services;

namespace SalonS.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private KundeRepository _kundeRepo;

    public IndexModel(ILogger<IndexModel> logger, KundeRepository kundeRepo)
    {
        _logger = logger;
        _kundeRepo = kundeRepo;
    }

    public IActionResult OnGet()
    {
        if (_kundeRepo is null || _kundeRepo.KundeLoggedIn is null)
        {
            return RedirectToPage("/Login");
        }

        return Page();
    }
}