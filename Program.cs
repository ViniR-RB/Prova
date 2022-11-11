using Microsoft.EntityFrameworkCore;
using aspent.Models;

var builder = WebApplication.CreateBuilder(args);
// Entregantes : Weslley David e Vinicius Roosevelt


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(options => options.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=prova;User Id=postgres;Password=postgres"));

var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
