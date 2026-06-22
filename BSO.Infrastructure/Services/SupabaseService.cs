using Microsoft.Extensions.Configuration;
using Supabase;
using BSO.Infrastructure.Models;

namespace BSO.Infrastructure.Services;

public class SupabaseService
{
    private readonly Supabase.Client _client;

    public SupabaseService(IConfiguration config)
    {
        var url = config["Supabase:Url"];
        var key = config["Supabase:AnonKey"];

        _client = new Supabase.Client(url, key);

        // ✅ Initialize client
        _client.InitializeAsync().Wait();
    }

    // ✅ Get raw client (used for inserts)
    public Supabase.Client GetClient()
    {
        return _client;
    }

    // ✅ REGISTER
    public async Task<bool> SignUp(string email, string password)
    {
        var response = await _client.Auth.SignUp(email, password);
        return response?.User != null;
    }

    // ✅ LOGIN
    public async Task<bool> SignIn(string email, string password)
    {
        var response = await _client.Auth.SignIn(email, password);
        return response?.User != null;
    }

    // ✅ LOGOUT
    public void SignOut()
    {
        _client.Auth.SignOut();
    }

    // ✅ GET CURRENT USER EMAIL
    public string? GetUserEmail()
    {
        return _client.Auth.CurrentUser?.Email;
    }

    // ✅ GET PROJECT COUNT (filtered by user)
    public async Task<int> GetProjectsCount(string email)
    {
        var result = await _client
            .From<Project>()
            .Filter("user_email",
                Supabase.Postgrest.Constants.Operator.Equals,
                email)
            .Get();

        return result.Models.Count;
    }

    // ✅ GET ALL PROJECTS (filtered by user)
    public async Task<List<Project>> GetProjects(string email)
    {
        var result = await _client
            .From<Project>()
            .Filter("user_email",
                Supabase.Postgrest.Constants.Operator.Equals,
                email)
            .Get();

        return result.Models;
    }
}
