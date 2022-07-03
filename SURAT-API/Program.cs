using SURAT_API.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SURAT_API.Helpers;
using SURAT_API.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SuratinContext>(options =>
                   options.UseMySql(builder.Configuration.GetConnectionString("SuratinDB"), new MySqlServerVersion(new Version())));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IDataRepository, DataRepository>();

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
app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    .WithOrigins("http://localhost:4200"));

app.MapControllers();

app.Run();
