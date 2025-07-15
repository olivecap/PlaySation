using Microsoft.EntityFrameworkCore;
using PlayStationApi.Data;

namespace PlayStationApiService.Data
{
    public static class DataExtension
    {
        //Allow to start automatically migration when you start App
        public static async Task MigrateDBAsync(this WebApplication app)
        {
            // Create scope
            using var scope = app.Services.CreateScope();

            // Get service register in Program?cs file using injection
            var dbContext = scope.ServiceProvider.GetRequiredService<PlayStationDbContext>();

            // Migrate
            await dbContext.Database.MigrateAsync();
        }
    }
}
