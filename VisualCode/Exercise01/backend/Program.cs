
using Exercise01.Context;
using Microsoft.EntityFrameworkCore;

string Exercise01JSDomain = "_Exercise01JSDomain";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Exercise01Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerveConnectString"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Exercise01JSDomain,
    policy=>policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(Exercise01JSDomain);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();