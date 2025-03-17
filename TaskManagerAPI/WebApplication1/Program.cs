using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManager API", Version = "v1" });
});

// Configuración de la conexión a la base de datos (SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilitar CORS para permitir solicitudes desde el frontend (Angular)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // Dirección de tu aplicación Angular
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Agregar controladores (API)
builder.Services.AddControllers();

var app = builder.Build();

// Habilitar Swagger y Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API v1");
        c.RoutePrefix = string.Empty; // Esto hará que Swagger UI se muestre en la raíz del proyecto
    });
}

// Habilitar CORS
app.UseCors("AllowAngular");

// Habilitar autenticación y autorización
app.UseAuthorization();

// Mapear las rutas de los controladores
app.MapControllers();

// Iniciar la aplicación
app.Run();
