using BSO.Domain;
using BSO.Infrastructure.Models;
using BSO.Infrastructure.Services;
namespace BSO.Infrastructure.Repositories;
public class UserRepository
{
    private readonly SupabaseService _supabase;

    public UserRepository(SupabaseService supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var client = _supabase.GetClient();

        var result = await client
            .From<SupabaseUser>()
            .Get();

        // ✅ map to domain model
        return result.Models.Select(x => new User
        {
            Id = x.Id,
            Email = x.Email
        }).ToList();
    }
}