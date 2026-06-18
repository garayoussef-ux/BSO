using BSO.Infrastructure.Services;
using BSO.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add Razor Pages
builder.Services.AddRazorPages();

// ✅ Register Supabase service (Singleton)
builder.Services.AddSingleton<SupabaseService>();

// ✅ Register repository
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

// ✅ Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ Map Razor Pages
app.MapRazorPages();

app.Run();