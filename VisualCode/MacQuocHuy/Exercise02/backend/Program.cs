
using MacQuocHuy.Exercise02.Context;
using Microsoft.EntityFrameworkCore;

string Exercise02JSDomain = "_Exercise02JSDomain";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Exercise02Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerveConnectString"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Exercise02JSDomain,
    policy=>policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(Exercise02JSDomain);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();