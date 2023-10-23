using DAL;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using DesafioProsegur.Bussines;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EFContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DatabaseConnection"),
        sqliteOptionsAction: op => {
            op.MigrationsAssembly(
                Assembly.GetExecutingAssembly().FullName
                );
        }
    )
);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".MyApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Puedes ajustar el tiempo de expiración según tus necesidades
});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPedidoMediator, PedidoMediator>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<EFContext>(); // Reemplaza EFContext con el nombre de tu DbContext.

    var dataInitializer = new DataInitializer();
    dataInitializer.InsertarDataInicial(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();