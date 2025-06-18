using EstoqueWeb.Application;
using EstoqueWeb.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o suporte ao MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

// Configura o Entity Framework Core com SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<IProdutoServices, ProdutoServices>(opt =>
{
    opt.BaseAddress = new("https://localhost:7100");
});

builder.Services.AddHttpClient<ILojaServices, LojaServices>(opt =>
{
    opt.BaseAddress = new("https://localhost:7100");
});

builder.Services.AddHttpClient<IItemEstoqueServices, ItemEstoqueServices>(opt =>
{
    opt.BaseAddress = new("https://localhost:7100");
});


var app = builder.Build();

// Configura o pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Define a rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
