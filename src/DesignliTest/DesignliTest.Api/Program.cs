using DesignliTest.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddApiConfiguration();

var app = builder.Build();

app.ApplySeed();
app.UseApiConfiguration();

app.Run();
