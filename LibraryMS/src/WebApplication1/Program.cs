
using Microsoft.AspNetCore.Http;
using LibMan.Data;
using libMan.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using libMan.Services.BookService;
using Microsoft.Extensions.Options;
using libMan.Services.Registration;
using LibMan.Data.Rentals;
using libMan.Services.RentalService;


//Step1 create blue print/ builder

var builder = WebApplication.CreateBuilder(args);
//Step 2 Add services
builder.Services.AddControllers();
builder.Services.AddLogging();
builder.Services.AddDbContext<LibDbContext>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors((options)=>
{
    options.AddPolicy("Dev", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

//AdminRespoitary of type  IAdminRepositary added as serice

builder.Services.AddScoped<IAdminRepositary, AdminRepositary>();
builder.Services.AddScoped<IAuthenticationService, DefaultAuthService>(); 
builder.Services.AddScoped<IBookRepositary, BookRepositary>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IRegistrationService,RegistrationService>();

builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");

});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SOme random key keyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy"))


    };
});

//Step 3 Build the application
var app = builder.Build();
app.UseStaticFiles(); // to let ASo.net send the static files likeimages,txt,pdf etc

//Step 4  Setup middleware like, how http request is responded

app.UseCors("Dev");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
//step 5 Run the application;


app.Run();