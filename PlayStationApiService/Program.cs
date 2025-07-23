using PlayStationApi.Data;
using PlayStationApi.Entities;
using PlayStationApiService.Data;
using PlayStationApiService.Endpoints;

var builder = WebApplication.CreateBuilder(args);

//-----------------------
// Data Base definition -
//-----------------------
// Connection string 
var connectionSqlDb = builder.Configuration.GetConnectionString("PlayStationStore");
// DB request
builder.Services.AddSqlite<PlayStationDbContext>(connectionSqlDb);

var app = builder.Build();

//--------------------------------------------
//  USE EXTENSION APP TO ADD GAMES ENDPOINTS
//--------------------------------------------
app.MapPlayersEndpoints();

//----------------------
// Data Base Migration -
//----------------------
// Run migration
await app.MigrateDBAsync();


app.MapGet("/", () => "Hello World!");

app.Run();
