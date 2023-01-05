using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using TFE.Application;
using TFE.Infrastructure;
using Microsoft.AspNetCore.Identity;
using TFE.Infrastructure.Identity;
using TFE.WebApi.OptionsSetup;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Auth",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insert token"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddApplication();
builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddIdentity();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    //.AddJwtBearer();
    .AddJwtBearer(options =>
    {
        JwtOptions jwtOptions = new JwtOptions();
        builder.Configuration.GetRequiredSection("Jwt").Bind(jwtOptions);

        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
        };
    });

// builder.Services.AddAuthorization();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.Logger.LogInformation("Seeding Database...");

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var userManager = scopedProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = scopedProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
        var applicationDbContext = scopedProvider.GetRequiredService<ApplicationDbContext>();
        await ApplicationDbContextSeed.SeedAsync(applicationDbContext, userManager, roleManager);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
