using Microsoft.EntityFrameworkCore;
using WebAPIDemo2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<MovieContext>(

    options =>
    {

        options.UseSqlServer(builder.Configuration.GetConnectionString("MyConn"));
    }
    
    );

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
