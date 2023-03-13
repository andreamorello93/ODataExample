using ODataExample.Api.Extensions;
using ODataExample.DAL.Data;
using Microsoft.EntityFrameworkCore;
using ODataExample.Application.Const;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataExample.Api.Swagger;
using ODataExample.Application.DTOs;
using ODataExample.DAL.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers()
    .AddOData(options => options
        .EnableQueryFeatures(Constants.PAGE_SIZE)
        .AddRouteComponents("odata", GetEdmModel())
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<ODataOperationFilter>();
    c.OperationFilter<SwaggerHideFilter>();
});

builder.Services.AddDbContext<AdventureWorks2019Context>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();

    builder.EntitySet<Customer>("Customer");
    builder.EntitySet<ProductDTO>("Product").EntityType.HasKey(p => p.ProductId);

    return builder.GetEdmModel();
}