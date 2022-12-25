using Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.ConfigureMyLogging();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureDependencies();
builder.Services.ConfigureAuthentication();
builder.Services.ConfigurePolicies();
builder.Services.ConfigureSession();
builder.Services.ConfigureAppCookies();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureCors();
builder.Services.ConfigureHttpCacheHeaders();
builder.Services.ConfigureRateLimiting();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(MapperInitializer));
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
