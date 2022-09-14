using CalculationAPI.Calculation.Messaging.Receive;
using CalculationAPI.Calculation.Messaging.Send;
using CalculationAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICalculationService, CalculationService>();
builder.Services.AddScoped<ICalculationResultSender, CalculationResultSender>();
builder.Services.AddHostedService<CalculationReceiver>();

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

app.Run();