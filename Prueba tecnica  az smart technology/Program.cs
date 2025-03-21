using AccesoDatos.Data;
using AccesoDatos.Data.UnitOfWork.Implementacion;
using AccesoDatos.Data.UnitOfWork.Interfaz;
using Microsoft.EntityFrameworkCore;
using Servicio.Implementacion;
using Servicio.Interfaz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Configuración de la cadena de conexión a SQL Server
string ConnectionString = builder.Configuration.GetConnectionString("ConexionSQL");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => 
    options.UseSqlServer(ConnectionString));

// UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Service
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<IAutorService, AutorService>();



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
    pattern: "{controller=Libro}/{action=Index}/{id?}");

app.Run();
