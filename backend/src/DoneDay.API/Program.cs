using DoneDay.Infrastructure.Data;          // DoneDayDbContext için
using DoneDay.Core.Interfaces;             // IHabitRepository için
using DoneDay.Infrastructure.Repositories; // HabitRepository için
using Microsoft.EntityFrameworkCore;       // UseSqlite için

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ DbContext ekle
builder.Services.AddDbContext<DoneDayDbContext>(options =>
    options.UseSqlite("Data Source=doneday.db"));

// 2️⃣ Repository ekle
builder.Services.AddScoped<IHabitRepository, HabitRepository>();

// 3️⃣ Controllers ve Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
