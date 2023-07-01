using Api.SUS.Application;
using Api.SUS.Client;
using Api.SUS.Data;
using Api.SUS.Data.Contexts;
using Api.SUS.Domain;
using Api.SUS.Domain.Notifications;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.Filters.Add<NotificationFilter>());

builder.Services.AddSusClient(builder.Configuration["IntegracaoSus:Uri"]);
builder.Services.AddDbContext<SqlContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ApiSUS")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddInfraDependencyInjection();
builder.Services.AddDomainDependencyInjection();
builder.Services.AddApplicationDependencyInjection();

var app = builder.Build();

app.Run();
