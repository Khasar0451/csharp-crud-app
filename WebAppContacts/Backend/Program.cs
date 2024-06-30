using WebAppContacts.Server.Data;
using Microsoft.EntityFrameworkCore;
using WebAppContacts.Server.Repositories;
using WebAppContacts.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ContactContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddCors();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();    //it is recommended for Repository to have scoped lifetime
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });    //this should be changed to something more strict

app.UseAuthorization();

app.MapControllers();
    
app.MapFallbackToFile("/index.html");

app.Run();
