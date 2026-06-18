using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BSO.Infrastructure.Models;

[Table("users")]
public class SupabaseUser : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("email")]
    public string Email { get; set; } = "";
}