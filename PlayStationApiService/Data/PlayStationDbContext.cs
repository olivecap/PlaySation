using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlayStationApi.Entities;

namespace PlayStationApi.Data
{
    /// <summary>
    /// Play station DB context
    /// </summary>
    public class PlayStationDbContext(DbContextOptions < PlayStationDbContext > options)
        : DbContext(options)
    {
        /// <summary>
        ///  Table players
        /// </summary>
        DbSet<PlayerEntity> Players => Set<PlayerEntity>();

        /// <summary>
        /// Allow to override int id to guid
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerEntity>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");
        }
    } 
}
