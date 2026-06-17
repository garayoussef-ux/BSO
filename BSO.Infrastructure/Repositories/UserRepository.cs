using Dapper;
using BSO.Domain;
using BSO.Infrastructure.Data;

namespace BSO.Infrastructure.Repositories;

public class UserRepository
{
    private readonly DbConnectionFactory _factory;

    public UserRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var connection = _factory.CreateConnection();
        var sql = "SELECT id, email FROM users";
        return await connection.QueryAsync<User>(sql);
    }
}