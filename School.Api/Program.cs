using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using School.Application;
using School.Application.Handlers.CourseHandelers.Commands_.CreateCourse;
using School.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register validators from Application layer assembly

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext
builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//register application(midiatR,automapper)
builder.Services.AddApplication();

// register Infrastructure
builder.Services.AddInfrastructure();
var app = builder.Build();

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
