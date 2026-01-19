// 1. Agregamos los usings que antes estaban en el Container
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;
using Domain.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Fernando el Visual Studio se me ha puesto gracioso y UI no queria ver a DI por lo que
// He puesto aqui lo que hace Container y no lo he utilizado de DI directamente
// No he sabido hacerlo de otra forma por eso UI ve a Data

builder.Services.AddControllersWithViews();

// 2. Registro directo de Inyección de Dependencias (DI)
// --- Repositorios ---
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();

// --- Casos de Uso ---
builder.Services.AddScoped<IListadoUseCase, ListadoUseCase>();
builder.Services.AddScoped<IComprobarUseCase, ComprobarUseCase>();

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
    pattern: "{controller=Game}/{action=Index}/{id?}");

app.Run();