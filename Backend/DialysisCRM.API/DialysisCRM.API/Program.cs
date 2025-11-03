using DialysisCRM.API.Data;
using DialysisCRM.API.Interfaces;
using DialysisCRM.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// ✅ Add Controllers
builder.Services.AddControllers();

// ✅ Swagger (for API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Database Context (PostgreSQL)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Enable CORS (optional but useful if your frontend runs separately)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()      // later, you can restrict to your frontend URL
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();

// ✅ Use CORS policy
app.UseCors("AllowFrontend");

// ✅ Swagger only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Optional: redirect HTTP → HTTPS
app.UseHttpsRedirection();

// ✅ Authorization
app.UseAuthorization();

// ✅ Map controllers
app.MapControllers();

// ✅ Run the application
app.Run();
