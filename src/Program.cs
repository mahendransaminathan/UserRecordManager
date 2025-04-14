using UserProfile.Repositories;
using UserProfile.Services;
using UserProfile.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddControllers(); // Registers controllers
builder.Services.AddEndpointsApiExplorer(); // Adds support for API documentation
builder.Services.AddSwaggerGen(); // Adds Swagger generation

// Add SQLite DbContext
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlite("Data Source=user.db")); // or any filename you want

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("http://localhost:5037"                          
                                        )  // Allow your frontend's URL

                          .AllowAnyHeader()                   // Allow all headers
                          .AllowAnyMethod()                   // Allow all methods (GET, POST, etc.)
                          .AllowCredentials());
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
// Use CORS policy globally
app.UseCors("AllowLocalhost");
app.MapControllers(); // Maps controller routes
app.Run();

