using Api.SUS.Application;
using Api.SUS.Client;
using Api.SUS.Data;
using Api.SUS.Domain;
using Api.SUS.Domain.Notifications;
using Api.SUS.Presentation.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>());

builder.Services.AddSusClient(builder.Configuration["IntegracaoSus:Uri"]);
builder.Services.AddInfraDependencyInjection(builder.Configuration);
builder.Services.AddDomainDependencyInjection();
builder.Services.AddApplicationDependencyInjection();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

CorsConfiguration.AddCors(builder.Services);
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

CorsConfiguration.UseCors(app);

app.MapControllers();

app.Run();
