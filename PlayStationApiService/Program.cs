using PlayStationApi.Data;
using PlayStationApi.Entities;
using PlayStationApiService.Data;

var builder = WebApplication.CreateBuilder(args);

//-----------------------
// Data Base definition -
//-----------------------
// Connection string 
var connectionSqlDb = builder.Configuration.GetConnectionString("PlayStationStore");
// DB request
builder.Services.AddSqlite<PlayStationDbContext>(connectionSqlDb);

var app = builder.Build();

//----------------------
// Data Base Migration -
//----------------------
// Run migration
await app.MigrateDBAsync();


app.MapGet("/", () => "Hello World!");

app.Run();
