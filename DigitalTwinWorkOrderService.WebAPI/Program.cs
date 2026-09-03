using DigitalTwinWorkOrderService.Endpoints;
using DigitalTwinWorkOrderService.WebAPI.Data;
using DigitalTwinWorkOrderService.WebAPI.Endpoints;
using DigitalTwinWorkOrderService.WebAPI.Endpoints.WorkOrders;
using DigitalTwinWorkOrderService.WebAPI.Interfaces;
using DigitalTwinWorkOrderService.WebAPI.Interfaces.WorkOrders;
using DigitalTwinWorkOrderService.WebAPI.Services;
using DigitalTwinWorkOrderService.WebAPI.Services.WorkOrders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add the DbContext to the service container
builder.Services.AddDbContext<WorkOrderWebServiceWebAPIDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add the static data services.
builder.Services.AddScoped<ISiteService, SiteService>();
builder.Services.AddScoped<IExternalSystemService, ExternalSystemService>();

// Add the Work Order services.
builder.Services.AddScoped<IWorkOrderStatusService, WorkOrderStatusService>();
builder.Services.AddScoped<IWorkOrderService, WorkOrderService>();
builder.Services.AddScoped<IWorkOrderHistoryService, WorkOrderHistoryService>();
builder.Services.AddScoped<IWorkOrderEventService, WorkOrderEventService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Add the endpoints.
app.MapSiteEndpoints();
app.MapExternalSystemEndpoint();
app.MapWorkOrderStatusEndpoints();
app.MapWorkOrderEndpoints();
app.MapWorkOrderHistoryEndpoint();
app.MapWorkOrderEventEndpoints();

app.Run();
