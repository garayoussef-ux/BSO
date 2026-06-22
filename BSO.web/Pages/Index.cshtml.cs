using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BSO.Infrastructure.Services;
using BSO.Infrastructure.Models;

public class IndexModel : PageModel
{
    private readonly SupabaseService _supabase;

    public string? Email { get; set; }

    public int ProjectsCount { get; set; }

    public List<Project> Projects { get; set; } = new();

    public IndexModel(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var email = HttpContext.Session.GetString("UserEmail")?.ToLower();

ProjectsCount = await _supabase.GetProjectsCount(email);
Projects = await _supabase.GetProjects(email);


        if (email == null)
        {
            return RedirectToPage("/Login");
        }

        // ✅ normalize email (important!)
        email = email.ToLower();

        Email = email;

        // ✅ get count
        ProjectsCount = await _supabase.GetProjectsCount(email);

        // ✅ get full list
        Projects = await _supabase.GetProjects(email);

        return Page();
    }
}
