using Data;
using Microsoft.EntityFrameworkCore;
using System;
using WebCoppel.Extenciones;
using WebCoppel.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AgregarServicioAplicacion(builder.Configuration);

builder.Services.AgregarServicioIdentidad(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errores/{0}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
