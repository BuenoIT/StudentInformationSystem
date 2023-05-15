using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.API.DataModels;
using StudentInformationSystem.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("StudentInformationSystemDb")));

builder.Services.AddScoped<IStudentRepository, SqlStudentRepository>();

builder.Services.AddCors((options) =>
{
    options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .WithMethods("GET", "POST", "PUT", "DELETE")
                .WithExposedHeaders("*");
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
