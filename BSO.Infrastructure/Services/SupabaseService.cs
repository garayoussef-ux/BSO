using Microsoft.Extensions.Configuration;
using Supabase;

namespace BSO.Infrastructure.Services;

public class SupabaseService
{
    private readonly Supabase.Client _client;

    public SupabaseService(IConfiguration config)
    {
        var url = config["Supabase:Url"];
        var key = config["Supabase:AnonKey"];

        _client = new Supabase.Client(url, key);
        _client.InitializeAsync().Wait();
    }

    public Supabase.Client GetClient()
    {
        return _client;
    }
    public async Task<bool> SignUp(string email, string password)
{
    var response = await _client.Auth.SignUp(email, password);
    return response?.User != null;
}

public async Task<bool> SignIn(string email, string password)
{
    var response = await _client.Auth.SignIn(email, password);
    return response?.User != null;
}

public string? GetUserEmail()
{
    return _client.Auth.CurrentUser?.Email;
}

public void SignOut()
{
    _client.Auth.SignOut();
}
}