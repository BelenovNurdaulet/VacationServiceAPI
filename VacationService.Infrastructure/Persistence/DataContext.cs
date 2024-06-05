using Microsoft.EntityFrameworkCore;
using VacationService.Application.Interfaces;
using VacationService.Domain.Entities;

namespace VacationService.Infrastructure.Persistence;

public class DataContext : DbContext, IDataContext
{
   public DbSet<User> Users { get; set; }
   //Vacation
   public DbSet<VacationsApplication> VacationsApplications { get; set; }
   public DbSet<VacationStatusHistory> VacationStatusHistories { get; set; }
   public DbSet<VacationApplicationType> VacationApplicationTypes { get; set; }
   public DbSet<VacationApplicationStatus> VacationApplicationStatuses { get; set; }
   
   //Document
   public DbSet<Document> Documents { get; set; }
   public DbSet<TemplateType> TemplateTypes { get; set; }
   public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
   
   public DbSet<DocumentSingInfo> DocumentSingInfos { get; set; }
   

   public DataContext(DbContextOptions<DataContext> options): base(options)
   {

   }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<VacationsApplication>()
            .ToTable("VacationsApplications", schema: "vac");
      
      modelBuilder.Entity<VacationStatusHistory>()
         .ToTable("VacationStatusHistories", schema: "vac");
      
      modelBuilder.Entity<VacationApplicationType>()
         .ToTable("VacationApplicationTypes", schema: "vac");
      
      modelBuilder.Entity<VacationApplicationStatus>()
         .ToTable("VacationApplicationStatuses", schema: "vac");
      
      modelBuilder.Entity<Document>()
         .ToTable("Documents", schema: "vac");
      
      modelBuilder.Entity<TemplateType>()
         .ToTable("TemplateTypes", schema: "vac");
      
      modelBuilder.Entity<DocumentTemplate>() 
         .ToTable("DocumentTemplates", schema: "vac");
      
      modelBuilder.Entity<DocumentSingInfo>()
         .ToTable("DocumentSingInfos", schema: "vac");
      
      modelBuilder.Entity<User>()
         .ToTable("Users", schema: "vac");
   //    
   //    modelBuilder.Entity<VacationsApplication>()
   //       .HasMany(e => e.Documents)
   //       .WithOne(e => e.VacationsApplication)
   //       .HasForeignKey(e => e.VacationApplicationId)
   //       .IsRequired();
      
   modelBuilder.Entity<VacationsApplication>()
      .HasMany(e => e.VacationStatusHistories)
      .WithOne(e => e.VacationsApplication)
      .HasForeignKey(e => e.ApplicationId); 
   //    
   //    modelBuilder.Entity<VacationsApplication>()
   //       .HasOne(e => e.VacationApplicationType)
   //       .WithOne(e => e.VacationsApplication)
   //       .HasForeignKey<VacationsApplication>(e => e.ApplicationTypeId)
   //       .IsRequired();
   //    
   //    modelBuilder.Entity<VacationsApplication>()
   //       .HasOne(e => e.VacationApplicationStatus)
   //       .WithOne(e => e.VacationApplication)
   //       .HasForeignKey<VacationsApplication>(e => e.StatusId)
   //       .IsRequired();
   //    
   //   
   //    
   //    modelBuilder.Entity<VacationStatusHistory>()
   //       .HasOne(e => e.VacationApplicationStatusOld)
   //       .WithOne(e => e.VacationStatusHistory)
   //       .HasForeignKey<VacationStatusHistory>(e => e.OldStatusId)
   //       .IsRequired();
   //    
   //    modelBuilder.Entity<User>()
   //       .HasMany(e => e.VacationsApplications)
   //       .WithOne(e => e.User)
   //       .HasForeignKey(e => e.CreatedBy)
   //       .IsRequired();
   //    
   //    modelBuilder.Entity<Document>()
   //       .HasOne(e => e.DocumentSingInfo)
   //       .WithOne(e => e.Document)
   //       .HasForeignKey<Document>(e => e.SignId)
   //       .IsRequired();
   //    
   //    modelBuilder.Entity<Document>()
   //       .HasOne(e => e.TemplateType)
   //       .WithOne(e => e.Document)
   //       .HasForeignKey<Document>(e => e.TemplateId)
   //       .IsRequired();
   //    
   //    modelBuilder.Entity<TemplateType>()
   //       .HasMany(e => e.DocumentTemplates)
   //       .WithOne(e => e.TemplateType)
   //       .HasForeignKey(e => e.TemplateTypeId)
   //       .IsRequired();
   //    
   //    modelBuilder.Entity<DocumentSingInfo>()
   //       .HasKey(dsi => dsi.Id);
   }
}