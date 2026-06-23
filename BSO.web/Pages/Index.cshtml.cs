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
        var email = HttpContext.Session.GetString("UserEmail");

        if (email == null)
            return RedirectToPage("/Login");

        email = email.ToLower();

        Email = email;
        Projects = await _supabase.GetProjects(email);
        ProjectsCount = await _supabase.GetProjectsCount(email);

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _supabase.DeleteProject(id);
        return RedirectToPage();
    }
}
