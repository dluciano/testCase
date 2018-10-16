﻿using Microsoft.EntityFrameworkCore;

namespace Clay.WebApi
{
    public class WebApiDbContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<LockEvent> LockEvents { get; set; }
        public DbSet<LockCard> LockCards { get; set; }
        public DbSet<Lock> Locks { get; set; }
        public DbSet<CardOwner> CardOwners { get; set; }
        public DbSet<CardGroupLock> CardGroupLocks { get; set; }
        public DbSet<CardGroup> CardGroups { get; set; }
        public DbSet<Card> Cards { get; set; }

        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<CardOwner>().HasOne(p => p.CurrentCard).WithOne(c => c.Owner);
        }
    }
}