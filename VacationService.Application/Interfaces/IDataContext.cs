using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using VacationService.Domain.Entities;

namespace VacationService.Application.Interfaces;

public interface IDataContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<VacationsApplication> VacationsApplications { get; set; }
    public DbSet<VacationStatusHistory> VacationStatusHistories { get; set; }
    public DbSet<VacationApplicationType> VacationApplicationTypes { get; set; }
    public DbSet<VacationApplicationStatus> VacationApplicationStatuses { get; set; }
    
   
    //Document
    public DbSet<Document> Documents { get; set; }
    public DbSet<TemplateType> TemplateTypes { get; set; }  
    public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
    public DbSet<DocumentSingInfo> DocumentSingInfos { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}   