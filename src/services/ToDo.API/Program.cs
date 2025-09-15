using ToDo.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiConfiguration(builder);
builder.Services.AddSwaggerConfiguration();
builder.Services.RegisterServices();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseApiConfiguration();