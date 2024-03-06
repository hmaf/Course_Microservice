//using Category.Api.Middleware;
using Category.Application;
using Category.Infrastractor;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ApplicationException = Category.Api.Exception.AppExceptionHandler;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplication();
builder.Services.AddInfrastractor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<ApplicationException>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });

app.UseAuthorization();

app.MapControllers();

app.Run();
