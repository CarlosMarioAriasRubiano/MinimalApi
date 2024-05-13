using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Context;
using MinimalApi.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PersistenceContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DevConnection")
    )
);

builder.Services.AddTransient(typeof(VehicleService));

var app = builder.Build();

app.MapGet("/vehicles", async (VehicleService service) =>
    await service.GetVehicles()
);

app.Run();
