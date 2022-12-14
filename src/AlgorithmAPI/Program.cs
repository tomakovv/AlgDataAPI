using AlgorithmAPI.Algorithm.Messaging.Recieve;
using AlgorithmAPI.Algorithm.Messaging.Send;
using AlgorithmAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddScoped<ISortService, SortService>();
builder.Services.AddScoped<ICalculationSender, CalculationSender>();
builder.Services.AddHostedService<CalculationResultReceiver>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();