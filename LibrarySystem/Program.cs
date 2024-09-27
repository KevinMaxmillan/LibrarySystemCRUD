
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Library.Infrastructure;
using LibrarySystem.Library.Application;
using LibrarySystem.Modules;
using LibrarySystem.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BooksDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DbConnectionString")));

builder.Services.AddAppication();
builder.Services.AddExceptionHandler<ExceptionHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });

app.AddBookEndpoints();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
