using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using STEP_backend.Architecture.Services;
using STEP_backend.Entity;
using STEP_backend.Services;


var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

configuration.AddJsonFile("secrets.json", optional: true);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IAICommunicationService, AICommunicationService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IPackageService, PackageServicecs>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    npgsqlOptions =>
    {
        npgsqlOptions.EnableRetryOnFailure();
    }
));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseCors(x => x
   .AllowAnyMethod()
   .AllowAnyHeader()
   .SetIsOriginAllowed(origin => true) // allow any origin
                                       //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
   .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
