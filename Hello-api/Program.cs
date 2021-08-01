var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IWeatherForecastController, WeatherForecastController>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
app.UseRouting();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Forecasts",

([FromServices] IWeatherForecastController weatherForecastController) =>
{
    var forcasts = weatherForecastController.Get();

    return forcasts;
});

app.Run();
