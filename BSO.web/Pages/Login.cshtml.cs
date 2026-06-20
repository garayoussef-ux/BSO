using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BSO.Infrastructure.Services;

public class LoginModel : PageModel
{
    private readonly SupabaseService _supabase;

    public LoginModel(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    [BindProperty]
    public string Email { get; set; } = "";

    [BindProperty]
    public string Password { get; set; } = "";

    public string ErrorMessage { get; set; } = "";

    public async Task<IActionResult> OnPostAsync()
    {
        var success = await _supabase.SignIn(Email, Password);

        if (!success)
        {
            ErrorMessage = "Login failed";
            return Page();
        }

        return RedirectToPage("/Index");
    }
}