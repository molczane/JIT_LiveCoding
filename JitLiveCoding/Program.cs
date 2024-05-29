using JitLiveCoding.Endpoints;
using JitLiveCoding.Data;

var builder = WebApplication.CreateBuilder(args);

// connection string to database
var connString = builder.Configuration.GetConnectionString("Visits");
builder.Services.AddSqlite<VisitsContext>(connString);

var app = builder.Build();

app.MapVisitsEndpoints();

app.MigrateDb();

app.Run();