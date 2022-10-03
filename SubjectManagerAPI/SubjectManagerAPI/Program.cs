using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using SubjectManagerAPI;
using SubjectManagerAPI.Entities;
using SubjectManagerAPI.Models;
using SubjectManagerAPI.Models.Validators;
using SubjectManagerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SubjectManagerDbContext>();
builder.Services.AddScoped<SubjectManagerSeeder>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
var app = builder.Build();
var db = new SubjectManagerDbContext();
var seeder = new SubjectManagerSeeder(db);

// Configure the HTTP request pipeline.
seeder.Seed();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
