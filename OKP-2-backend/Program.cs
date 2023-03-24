var builder = WebApplication.CreateBuilder(args);
string[] origins = { "http://localhost:8080", "https://localhost:8081" };
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policyBuilder => policyBuilder
        .WithOrigins(origins)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});
builder.Services.AddControllers();

// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseRouting();
app.MapControllers();

app.Run();
