using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManager API", Version = "v1" });
});

// Configuraci�n de la conexi�n a la base de datos (SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilitar CORS para permitir solicitudes desde el frontend (Angular)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // Direcci�n de tu aplicaci�n Angular
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
        c.RoutePrefix = string.Empty; // Esto har� que Swagger UI se muestre en la ra�z del proyecto
    });
}

// Habilitar CORS
app.UseCors("AllowAngular");

// Habilitar autenticaci�n y autorizaci�n
app.UseAuthorization();

// Mapear las rutas de los controladores
app.MapControllers();

// Iniciar la aplicaci�n
app.Run();
