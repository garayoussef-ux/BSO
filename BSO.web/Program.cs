using BSO.Infrastructure.Services;
using BSO.Infrastructure.Repositories;
using BSO.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AuthService>();
// ✅ Add Razor Pages
builder.Services.AddRazorPages();

// ✅ Register Supabase service (Singleton)
builder.Services.AddSingleton<SupabaseService>();

// ✅ Register repository
builder.Services.AddScoped<UserRepository>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession();

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
app.UseSession();

app.UseAuthorization();

// ✅ Map Razor Pages
app.MapRazorPages();

app.Run();