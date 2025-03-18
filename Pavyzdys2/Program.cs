using AutoParkas.Core.Contracts;
using AutoParkas.Core.Services;
using AutoParkas.Core.Utils;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
string sqlConnection = "Server=localhost\\MSSQLSERVER01;Database=automobiliai_ef;Trusted_Connection=True;TrustServerCertificate=true;";
// Add services to the container.
builder.Services.AddDbContext<AppDatabaseContext>(options => options.UseSqlServer(sqlConnection, b => b.MigrationsAssembly("Pavyzdys2")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAutoNuoma, AutoParkasService>();



Log.Logger = new LoggerConfiguration()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var app = builder.Build();
//GeneralInformationService generalInformationService = new GeneralInformationService(app.Services.GetService<AppDatabaseContext>());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Log.Information("API paleistas sekmingai");
app.Run();
