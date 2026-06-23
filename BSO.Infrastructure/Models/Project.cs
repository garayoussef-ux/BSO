using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BSO.Infrastructure.Models;

[Table("projects")]
public class Project : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; } = "";

    [Column("user_email")]
    public string UserEmail { get; set; } = "";

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}