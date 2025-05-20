using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using School.Application;
using School.Application.Handlers.CourseHandelers.Commands_.CreateCourse;
using School.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Hangfire;


var builder = WebApplication.CreateBuilder(args);

// hangfire
builder.Services.AddHangfire
    (x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangFireConnection")));
builder.Services.AddHangfireServer();

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


//authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

})
    .AddJwtBearer(options =>

    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issure"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))





        };
    });




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseHangfireDashboard("/dashboard");

app.MapControllers();

app.Run();
