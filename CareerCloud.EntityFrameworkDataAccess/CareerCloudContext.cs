    using CareerCloud.Pocos;
    using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

    namespace CareerCloud.EntityFrameworkDataAccess
    {
        public class CareerCloudContext : DbContext
        {
         public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<ApplicantEducationPoco> ApplicantEducation { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogin { get; set; }
        public CareerCloudContext(bool createProxy = true)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(@"Data Source=CSHARPHUMBER\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True");
                base.OnConfiguring(optionsBuilder);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<ApplicantEducationPoco>(entity =>
                {
                    entity.ToTable("Applicant_Educations");

                    entity.Property(e => e.Id).ValueGeneratedNever();

                    entity.Property(e => e.CertificateDiploma)
                        .HasColumnName("Certificate_Diploma")
                        .HasMaxLength(100);

                    entity.Property(e => e.CompletionDate)
                        .HasColumnName("Completion_Date")
                        .HasColumnType("date");

                    entity.Property(e => e.CompletionPercent).HasColumnName("Completion_Percent");

                    entity.Property(e => e.Major)
                        .IsRequired()
                        .HasMaxLength(100);

                    entity.Property(e => e.StartDate)
                        .HasColumnName("Start_Date")
                        .HasColumnType("date");

                    entity.Property(e => e.TimeStamp)
                        .IsRequired()
                        .HasColumnName("Time_Stamp")
                        .IsRowVersion()
                        .IsConcurrencyToken();

                });

                base.OnModelCreating(modelBuilder);
            }
        }
    }

