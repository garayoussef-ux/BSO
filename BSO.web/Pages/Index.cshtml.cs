using Microsoft.AspNetCore.Mvc.RazorPages;
using BSO.Infrastructure.Repositories;
using BSO.Domain;

public class IndexModel : PageModel
{
    private readonly UserRepository _repo;

    public IEnumerable<User> Users { get; set; } = new List<User>();

    public IndexModel(UserRepository repo)
    {
        _repo = repo;
    }

    public async Task OnGetAsync()
    {
        Users = await _repo.GetAllAsync();
    }
}