using EcomInfrastucture.Mapper;
using EcomGRPC;
using EcomGRPC.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddAutoMapper(typeof(ProductProfileMapper).Assembly);

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<ProductService>();
});
// Configure the HTTP request pipeline.

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
