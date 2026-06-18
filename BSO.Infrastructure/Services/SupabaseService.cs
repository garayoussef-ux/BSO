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
}