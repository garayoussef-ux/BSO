using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BSO.Infrastructure.Services;
using BSO.Infrastructure.Models;

public class EditProjectModel : PageModel
{
    private readonly SupabaseService _supabase;

    public EditProjectModel(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    [BindProperty]
    public Guid Id { get; set; }

    [BindProperty]
    public string Name { get; set; } = "";

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var email = HttpContext.Session.GetString("UserEmail");

        if (email == null)
            return RedirectToPage("/Login");

        email = email.ToLower();

        var projects = await _supabase.GetProjects(email);

        var project = projects.FirstOrDefault(p => p.Id == id);

        if (project == null)
            return RedirectToPage("/Index");

        Id = project.Id;
        Name = project.Name;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var client = _supabase.GetClient();

        await client
    .From<Project>()
    .Filter("id",
        Supabase.Postgrest.Constants.Operator.Equals,
        Id.ToString())
    .Update(new Project
    {
        Name = Name
    });


        return RedirectToPage("/Index");
    }
}
