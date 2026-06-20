using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BSO.Infrastructure.Services;

public class RegisterModel : PageModel
{
    private readonly SupabaseService _supabase;

    public RegisterModel(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    [BindProperty]
    public string Email { get; set; } = "";

    [BindProperty]
    public string Password { get; set; } = "";

    public string Message { get; set; } = "";

    public async Task<IActionResult> OnPostAsync()
    {
        var success = await _supabase.SignUp(Email, Password);

        if (success)
            Message = "✅ Account created! Check your email to confirm your account.";
        else
            Message = "❌ Error creating account. Try again.";

        return Page();
    }
}