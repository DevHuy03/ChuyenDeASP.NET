using Example06.Context;
using Microsoft.EntityFrameworkCore;
string Example06JSDomain = "_Example06JSDomain";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnectString"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Example06JSDomain,
    policy => policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(Example06JSDomain);

app.Run();