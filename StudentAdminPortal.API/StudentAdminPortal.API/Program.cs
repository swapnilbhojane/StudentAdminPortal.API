using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//IServiceCollection serviceCollection =
builder.Services.AddDbContext<StudentAdminContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdminPortalDb")));

builder.Services.AddScoped<IStudentRepository, SqlStudentRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((Options =>
{
    Options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");
    });
}));

//IServiceCollection serviceCollection = builder.Services.AddAutoMapper(typeof(Startup).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("angularApplication");

app.UseAuthorization();

app.MapControllers();

app.Run();
