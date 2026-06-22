namespace BSO.Application.Services;

public class AuthService
{
    public async Task<bool> Register(string email, string password)
    {
        // Placeholder (logic handled elsewhere for now)
        return true;
    }

    public async Task<bool> Login(string email, string password)
    {
        return true;
    }

    public void Logout()
    {
    }

    public string? GetCurrentUserEmail()
    {
        return null;
    }
}
