using Microsoft.EntityFrameworkCore;
using REST_Application_Demo.Repositories;
using REST_Application_Demo.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<REST_Application_Demo.Data.ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("BooksDb")); // Use an in-memory DB for demo purposes


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
