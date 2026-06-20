using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BSO.Infrastructure.Services;

public class LogoutModel : PageModel
{
    private readonly SupabaseService _supabase;

    public LogoutModel(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    public IActionResult OnPost()
    {
        _supabase.SignOut();   // ✅ logout
        return RedirectToPage("/Login"); // ✅ go back to login
    }
}
