using HackerNewsApi.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); //for swagger
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IHackerNewsService, HackerNewsService>();
builder.Services.AddCors(options =>
options.AddPolicy("AllowAll", policy =>
{
    policy.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
})
);


// Configure the HTTP request pipeline.
var app = builder.Build();
//if (app.Environment.IsDevelopment()) // You can remove this check if you always want Swagger
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
