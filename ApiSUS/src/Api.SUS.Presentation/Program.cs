using Api.SUS.Client;
using Api.SUS.Data.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMvc();

builder.Services.AddSusClient(builder.Configuration["IntegracaoSus:Uri"]);
builder.Services.AddDbContext<SqlContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ApiSUS")));

var app = builder.Build();

app.Run();
