using System.Reflection;
using System.Collections.Immutable;
using jwt.back.Core.Application.Interfaces;
using jwtapp.back.Persistance.Context;
using jwtapp.back.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using jwtapp.back.Core.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<JwtContext>(opt => {
opt.UseSqlite(builder.Configuration.GetConnectionString("Local"));
opt.EnableSensitiveDataLogging();
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(opt=>{
    opt.AddProfiles(new List<Profile>()
    {
        new ProductProfile()
    });
});
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
