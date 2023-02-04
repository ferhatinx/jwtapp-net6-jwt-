using System.Reflection;
using System.Collections.Immutable;
using jwt.back.Core.Application.Interfaces;
using jwtapp.back.Persistance.Context;
using jwtapp.back.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using jwtapp.back.Core.Application.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using jwtapp.back.Infrastructure.Tools;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<JwtContext>(opt => {
opt.UseSqlite(builder.Configuration.GetConnectionString("Local"));
opt.EnableSensitiveDataLogging();
});
//JWT
//Microsoft.AspNetCore.Authetication.JwtBearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>{
    opt.RequireHttpsMetadata = false; //HTTPS gerekli olsun mu ?
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateAudience=JwtTokenDefaults.ValidAudience,
        ValidateIssuer=JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero, //Token ile sunucu arasında saar farkı olsun mu ?
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,

    };
});



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(opt=>{
    opt.AddProfiles(new List<Profile>()
    {
        new ProductProfile(),
        new CategoryProfile()
    });
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
