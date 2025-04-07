using Application.DTOs;
using Application.Interfaces;
using Application.UsesCases.Students;
using Application.UsesCases.StudentSubjects;
using Infraestructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            return new OkObjectResult(new ResponseBaseDTO()
            {
                StatusCode = 400,
                Message = $"Errores de validación {string.Join(",", errors)}"
            });
        };
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200") // URL de tu app Angular
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Dependency Injection
builder.Services.AddDbContext<TestInterContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IStudentUseCase, StudentUseCase>();
builder.Services.AddScoped<IStudentSubjectUseCase, StudentSubjectUseCase>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
