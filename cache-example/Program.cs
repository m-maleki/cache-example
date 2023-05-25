using cache_example.Infrastructure.Cache.MemoryCache;
using cache_example.Infrastructure.Ef.Common;
using cache_example.Infrastructure.Ef.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=MASOUD;Initial Catalog=MyDatabase;Integrated Security=True;TrustServerCertificate=True"));

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IInMemoryCache, InMemoryCache>();


builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
