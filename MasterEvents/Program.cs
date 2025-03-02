using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Repository.Interfaces;
using System.Text;
using Service.Dtos;
using Service.Interfaces;
using Service.Services;
using Repository.Entity;
using Repository.Repositories;
using AutoMapper;
using Mock;

var builder = WebApplication.CreateBuilder(args);

// ����� appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// ����� ������� �� JWT �� �����
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? throw new ArgumentNullException("Jwt:Issuer is missing in configuration.");
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? throw new ArgumentNullException("Jwt:Audience is missing in configuration.");
var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key is missing in configuration.");

// ����� ������ ����� �� JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddScoped<IRepository<Event>, EventRepository>();
builder.Services.AddScoped<IService<EventDto>, EventService>();

builder.Services.AddScoped<IRepository<Group>, GroupRepository>();
builder.Services.AddScoped<IService<GroupDto>, GroupService>();

builder.Services.AddScoped<IRepository<Guest>, GuestRepository>();
builder.Services.AddScoped<IService<GuestDto>, GuestService>();

builder.Services.AddScoped<IRepository<Guest>, GuestRepository>();
builder.Services.AddScoped<IService<GuestDto>, GuestService>();

builder.Services.AddScoped<IRepository<GuestInEvent>, GuestInEventRepository>();
builder.Services.AddScoped<IService<GuestInEventDto>, GuestInEventService>();

builder.Services.AddScoped<IOrganizerRepository, OrganizerRepository>();
builder.Services.AddScoped<IOrganizerService, OrganizerService>();
builder.Services.AddScoped<IRepository<Organizer>, OrganizerRepository>(); // �� �-Repository ���� �� �-IRepository
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IRepository<PhotosFromEvent>, PhotosFromEventRepository>();
builder.Services.AddScoped<IService<PhotosFromEventDto>, PhotosFromEventService>();

builder.Services.AddScoped<IRepository<Seating>, SeatingRepository>();
builder.Services.AddScoped<IService<SeatingDto>, SeatingService>();

builder.Services.AddScoped<IRepository<SubGuest>, SubGuestRepository>();
builder.Services.AddScoped<IService<SubGuestDto>, SubGuestService>();

builder.Services.AddScoped<IContext, MyDataBase>();
builder.Services.AddAutoMapper(typeof(MyMapper));

// ����� ������ Authorization
builder.Services.AddAuthorization();

// ����� ����� �-Controllers
builder.Services.AddControllers();

// ����� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ����� CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

var app = builder.Build();

// ����� Swagger (������ ����)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ����� ����� �������
app.UseAuthentication();
app.UseAuthorization();

// ����� CORS
app.UseCors(MyAllowSpecificOrigins);

// ����� �� �-Controllers
app.MapControllers();

app.Run();
