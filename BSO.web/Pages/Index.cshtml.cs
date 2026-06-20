using Microsoft.AspNetCore.Mvc.RazorPages;
using BSO.Infrastructure.Services;

public class IndexModel : PageModel
{
    private readonly SupabaseService _supabase;

    public string? Email { get; set; }

    public IndexModel(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    public void OnGet()
    {
        Email = _supabase.GetUserEmail();
    }
}