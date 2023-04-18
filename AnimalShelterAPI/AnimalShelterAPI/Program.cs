using AnimalShelter.Data;
using AnimalShelter.Interfaces;
using AnimalShelter.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IKennelCapacityService, KennelCapacityService>();
builder.Services.AddTransient<IRemoveService, RemoveService>();
builder.Services.AddTransient<IReorganizeAnimalsService, ReorganizeAnimalsService>();
builder.Services.AddTransient<IShelterService, ShelterService>();
builder.Services.AddTransient<ISwapAnimalService, SwapAnimalService>();
builder.Services.AddTransient<IValidatorService, ValidatorService>();

builder.Services.AddTransient<IShelterKennelRepository, ShelterKennelRepository>();

builder.Services.AddTransient<IDbConnectionFactory, AnimalShelterConnectionFactory>();

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
