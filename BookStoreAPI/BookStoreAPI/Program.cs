using BookStoreAPI.Infrastructure;
using BookStoreAPI.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInfrastructure(builder.Environment);
builder.Services.AddApplicationServices(builder.Environment);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
