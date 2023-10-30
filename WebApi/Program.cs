using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Data;
using DataAccessLayer.DatabaseModels;
using WebApi.Services;
using DataAccessLayer.DatabaseContexts;
using DataAccessLayer.Repository;
using BusinessAccessLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DB Contexts Configurations
//builder.Services.AddDbContext<ContactContext>(options => options.UseInMemoryDatabase("ContactsDb"));
builder.Services.AddDbContext<EmployeeDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesApiConnectionStringSSMS"),b=>b.MigrationsAssembly("DataAccessLayer")));
builder.Services.AddDbContext<UserAuthContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeesApiConnectionStringSSMS")));


builder.Services.AddScoped<IEmployeeRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService<Employee>, EmployeeService>();




//Identity Configureations
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength=5;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
    }).AddEntityFrameworkStores<UserAuthContext>()
      .AddDefaultTokenProviders();
builder.Services.AddTransient<IAuthService, AuthService>();

//Authentication configurations
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:key").Value))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
