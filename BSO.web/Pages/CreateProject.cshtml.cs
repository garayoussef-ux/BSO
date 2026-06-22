using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BSO.Infrastructure.Services;
using BSO.Infrastructure.Models;

public class CreateProjectModel : PageModel
{
    private readonly SupabaseService _supabase;

    public CreateProjectModel(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    [BindProperty]
    public string Name { get; set; } = "";

    public string Message { get; set; } = "";

    public IActionResult OnGet()
    {
        var email = HttpContext.Session.GetString("UserEmail");

        if (email == null)
        {
            return RedirectToPage("/Login");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var email = HttpContext.Session.GetString("UserEmail");

        if (email == null)
        {
            return RedirectToPage("/Login");
        }

        email = email.ToLower();

        var client = _supabase.GetClient();

        await client.From<Project>().Insert(new Project
        {
            Name = Name,
            UserEmail = email
        });

        Message = "✅ Project created successfully!";

        return Page();
    }
}