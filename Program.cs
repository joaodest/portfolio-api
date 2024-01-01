
using Microsoft.EntityFrameworkCore;
using portfolio_api.Controllers;
using portfolio_api.Data;
using portfolio_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<LinkedInUserController>(
    client =>
    {
        client.BaseAddress = new Uri("https://api.linkedin.com/v2/userinfo/");
        //client.DefaultRequestHeaders.Add("Accept", "application/json");
    });

builder.Services.AddHttpClient<GithubUserController>(
       client =>
       {
           client.BaseAddress = new Uri("https://api.github.com/user");
           client.DefaultRequestHeaders.Add("User-Agent", "My GitHub App");

       });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ILinkedInUserRepository, LinkedInUserRepository>();
builder.Services.AddScoped<ILinkedInUserService, LinkedInUserService>();

builder.Services.AddScoped<IGithubUserRepository, GithubUserRepository>();
builder.Services.AddScoped<IGithubUserService, GithubUserService>();

builder.Services.AddScoped<IFeaturedProjectsRepository, FeaturedProjectsRepository>();
builder.Services.AddScoped<IFeaturedProjectsService, FeaturedProjectsService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();

app.Run();

