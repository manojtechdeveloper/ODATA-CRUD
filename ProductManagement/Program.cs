using System.Reflection.Emit;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ProductManagement.Service.IServices;
using ProductManagement.Service.Services;
using ProductManagement.ServicesDependencies;
using Microsoft.AspNetCore.OData.Extensions;
using ProductManagement.Controllers;
using ProductManagement.Repository.ProductDbContext;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository.BaseRepository;
using ProductManagement.Repository.Entities;
using ProductManagement.RepositoryDependencies;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.OData.Formatter;
using System.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Product", Version = "v1", Description="API Description" });
});
var modelBuilder = new ODataConventionModelBuilder();

modelBuilder.EntitySet<Account>("Accounts");
modelBuilder.EntitySet<Transaction>("Transaction");
builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()));

Services.InjectServices(builder);
Repositories.InjectRepositories(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Version 1");
});

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
