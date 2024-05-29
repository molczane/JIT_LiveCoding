using JitLiveCoding.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapVisitsEndpoints();

app.Run();