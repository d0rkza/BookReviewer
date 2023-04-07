using BookReviewer.Api.Controllers;
using BookReviewer.Business;
using BookReviewer.Business.BookReviewerService;
using BookReviewer.Extensions;
using BookReviewer.IBusiness;
using BookReviewer.Models;
using BookReviewer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

//Add localization support
builder.Services.AddMvc()
        .AddViewLocalization(
            LanguageViewLocationExpanderFormat.Suffix,
            opts => { opts.ResourcesPath = "Resources"; })
        .AddDataAnnotationsLocalization();

builder.Services.AddLocalization(options => options.ResourcesPath = "");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    { 
        new CultureInfo("en-us"),
        new CultureInfo("sl-si")
    };

    options.DefaultRequestCulture = new RequestCulture("en-us");
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-us") };
    options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-us") };
    options.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider { } };
});

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("culture", typeof(LanguageRouteConstraint));
});

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<string[]>(new[] { "en-us", "sl-si" });

builder.Services.AddSingleton<IStringLocalizerFactory, ResourceManagerStringLocalizerFactory>();
builder.Services.AddSingleton(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));

var allowedOrigins = "DevCORS";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44488",
                                              "https://localhost",
                                              "http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

ConfigurationManager configurationManager = builder.Configuration;
var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
var connectionString = config.GetConnectionString("DatabaseConnectionString");
builder.Services.AddDbContext<BookReviewerDbContext>(options => options.UseSqlServer(connectionString));

//Add services from other projects - not needed in simple apps
builder.Services.AddControllers().AddApplicationPart(typeof(BookController).Assembly);
builder.Services.AddTransient<IBookReviewerService, BookReviewerService>();
builder.Services.AddTransient<ICustomAuthenticationService, CustomAuthenticationService>();

////Register MediatR to see other projects - not needed in simple apps
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BookController).Assembly));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetBooksQueryHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

//Add authentication schema and JWT settings
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = configurationManager["JWT:ValidAudience"],
            ValidIssuer = configurationManager["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationManager["JWT:Secret"]))
        };
    });

//register custom services
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var localizeOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizeOptions.Value);

//Intercept token - debug purposes
app.Use(async (context, next) =>
{
    var authHeader = context.Request.Headers["Authorization"];
    if (!string.IsNullOrEmpty(authHeader))
    {
        var token = authHeader.ToString();
        Console.WriteLine($"Incoming token: {token}");
    }
    await next.Invoke();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{culture}/{controller}/{action}/{id?}",
        defaults: new { culture = "en-us" }
    );
});

app.MapControllers();

app.UseCors(allowedOrigins);

app.Run();
