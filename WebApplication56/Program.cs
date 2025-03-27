using Microsoft.EntityFrameworkCore;
using WebApplication56.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "BestStore API",
        Version = "v1",
        Description = "API for managing BestStore products, categories, and brands"
    });
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Content-Type");
        });
});

// Add DbContext
builder.Services.AddDbContext<BestStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BestStore API V1");
        c.RoutePrefix = string.Empty; // This will make Swagger UI the default page
    });
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("AllowAll");

// Use static files
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
