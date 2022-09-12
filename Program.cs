using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection") ?? throw new InvalidOperationException("Connection string 'BookContext' not found.")));

// builder.Services.AddDbContext<BookContext>(options =>
//     options.UseInMemoryDatabase("BookDb"));


// Add services to the container.

builder.Services.AddControllers();
// koneksi untuk data local db menggunakan InMemmory
// builder.Services.AddDbContext<ContactContext>(options =>
//     options.UseInMemoryDatabase("Contactdb"));
// using Microsoft.EntityFrameworkCore;
builder.Services.AddDbContext<ContactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
