using DAL;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System.Reflection;
using System.Text.Json.Serialization;

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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
