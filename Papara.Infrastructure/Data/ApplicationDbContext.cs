﻿using Microsoft.EntityFrameworkCore;
using Papara.Core.Entity;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<FakeData> FakeDatas { get; set; }
    }
}
