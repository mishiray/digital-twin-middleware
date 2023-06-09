﻿using DigitalTwinMiddleware.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalTwinMiddleware.Data
{

    public class AppDbContext : IdentityDbContext<User>
    {

        public DbSet<IOTDevice> IOTDevices { get; set; }
        public DbSet<Telemetry> Telemetries { get; set; }
        public DbSet<DefaultLog> DefaultLogs { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
