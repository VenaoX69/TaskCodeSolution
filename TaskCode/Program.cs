using Microsoft.EntityFrameworkCore;
using TaskCode.Commands;
using TaskCode.Data;
using TaskCode.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CarteraDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<CreateCategoriaCreditoCommandHandler>();
builder.Services.AddScoped<GetCategoriaCreditoQueryHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
