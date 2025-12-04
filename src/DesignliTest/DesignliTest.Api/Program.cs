using DesignliTest.Core.Interface.Repository;
using DesignliTest.Infrastructure.Repository;
using DesignliTest.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// EF InMemory (Repositories project)
builder.Services.AddScoped<DbContext, AppDbContext>();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("DesignliDb"));

// DI registrations
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

// Add services to the container.
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
