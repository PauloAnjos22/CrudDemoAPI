using CrudDemoAPI.AutoMapper;
using CrudDemoAPI.Data;
using CrudDemoAPI.DTOs;
using CrudDemoAPI.Interfaces;
using CrudDemoAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ConfigurationMapping>();
}); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>
    (opt =>
        opt.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    );

builder.Services.AddScoped<ICrudService<CustomerCreateDTO, CustomerUpdateDTO, CustomerDTO>, CustomerService>();

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
