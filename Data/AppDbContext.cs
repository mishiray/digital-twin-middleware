using DigitalTwinMiddleware.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DigitalTwinMiddleware.Data
{

    public class AppDbContext : IdentityDbContext<User>
    {

        public DbSet<IOTDevice> IOTDevices { get; set; }
        public DbSet<Telemetry> Telemetries { get; set; }
        public DbSet<DefaultLog> DefaultLogs { get; set; }
        public DbSet<DeviceRelationship> DeviceRelationships { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<DeviceRelationship>()
            //.HasOne(dr => dr.DeviceOneCondition)
            //.WithMany()
            //.HasForeignKey(dr => dr.DeviceOneConditionId)
            //.IsRequired();

            //builder.Entity<DeviceRelationship>()
            //.HasOne(dr => dr.DeviceTwoReaction)
            //.WithMany()
            //.HasForeignKey(dr => dr.DeviceTwoReactionId)
            //.IsRequired();

            base.OnModelCreating(builder);
        }
    }
}
