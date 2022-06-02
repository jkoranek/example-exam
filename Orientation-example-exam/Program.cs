using Orientation_example_exam.Data;
using Orientation_example_exam.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddScoped<IUserService, UserService>();

ConfigureDb(builder.Services);

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();

static void ConfigureDb(IServiceCollection services)
{
    var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
    var connectionString = config.GetConnectionString("Default");
    services.AddDbContext<ApplicationContext>(b => b.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
}

public partial class Program { }