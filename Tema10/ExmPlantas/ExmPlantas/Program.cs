using Proyecto.DI; // Importante: el namespace donde está tu Container.cs

var builder = WebApplication.CreateBuilder(args);

// --- SECCIÓN DE SERVICIOS ---

// Aquí es donde registras tus interfaces y clases
// Llama al método que creamos en la carpeta DI
Container.RegisterServices(builder.Services);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// --- SECCIÓN DE MIDDLEWARE (Configuración de rutas) ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Configuración de la ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();