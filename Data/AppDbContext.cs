﻿using crp_api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace crp_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> USERS { get; set; }

        public DbSet<Report> REPORTS { get; set; }
        public DbSet<ReportLog> REPORTLOGS { get; set; }
        public DbSet<ReportStatus> REPORTSTATUSES { get; set; }
        public DbSet<ReportType> REPORTTYPES { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("crp");
            modelBuilder
                .Entity<User>()
                .Property(u => u.USER_ID)
                .HasDefaultValueSql("newsequentialid()");
            modelBuilder
                .Entity<Report>()
                .Property(t => t.REPORT_ID)
                .HasDefaultValueSql("newsequentialid()");
            modelBuilder
                .Entity<ReportLog>()
                .Property(t => t.REPORTLOG_ID)
                .HasDefaultValueSql("newsequentialid()");
            modelBuilder
                .Entity<ReportStatus>()
                .Property(t => t.REPORTSTATUS_ID)
                .HasDefaultValueSql("newsequentialid()");
            modelBuilder
                .Entity<ReportType>()
                .Property(t => t.REPORTTYPE_ID)
                .HasDefaultValueSql("newsequentialid()");
            modelBuilder
                .Entity<Report>()
                .HasOne(r => r.USER)
                .WithMany(r => r.REPORTS) 
                .HasForeignKey(u => u.USER_ID);
            modelBuilder
                .Entity<Report>()
                .HasOne(r => r.REPORTTYPE)
                .WithMany(r => r.REPORTS)
                .HasForeignKey(r => r.REPORTTYPE_ID);
            modelBuilder
                .Entity<Report>()
                .HasOne(r => r.REPORTTYPE)
                .WithMany(r => r.REPORTS)
                .OnDelete(DeleteBehavior.ClientNoAction);
             modelBuilder
                .Entity<ReportLog>()
                .HasOne(r => r.REPORT)
                .WithMany(r => r.REPORTLOGS)
                .HasForeignKey(r => r.REPORT_ID);
            modelBuilder
                .Entity<ReportLog>()
                .HasOne(r => r.REPORT)
                .WithMany(r => r.REPORTLOGS)
                .OnDelete(DeleteBehavior.ClientNoAction);
            modelBuilder
               .Entity<Report>()
               .HasOne(r => r.REPORTSTATUS)
               .WithMany(r => r.REPORTS)
               .HasForeignKey(r => r.REPORTSTATUS_ID);

        }
    }
}