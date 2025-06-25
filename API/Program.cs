using Application.DTOs;
using Application.Interfaces;
using Application.Mappers;
using Application.Presenters;
using Application.UseCases;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Usuario>, UsuarioRepository>();
builder.Services.AddScoped<IMapper<AddUsuarioRequestDTO, Usuario>, AddUsuarioMapper>();
builder.Services.AddScoped<IPresenter<Usuario, UsuarioResponseDTO>, UsuarioPresenter>();

// Register Use Cases
builder.Services.AddScoped<AddUsuarioUseCase<AddUsuarioRequestDTO>>();
builder.Services.AddScoped<GetUsuarioUseCase<Usuario, UsuarioResponseDTO>>();
builder.Services.AddScoped<UpdateUsuarioUseCase>();
builder.Services.AddScoped<DeleteUsuarioUseCase>();

var app = builder.Build();

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while creating the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
