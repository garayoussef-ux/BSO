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

    public void SignOut()
    {
        _client.Auth.SignOut();
    }

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

    public async Task DeleteProject(Guid id)
    {
        await _client
            .From<Project>()
            .Filter("id",
                Supabase.Postgrest.Constants.Operator.Equals,
                id.ToString())
            .Delete();
    }
}
