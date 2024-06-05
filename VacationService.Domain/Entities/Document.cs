
namespace VacationService.Domain.Entities;


public class Document
{
    
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int ApplicationId { get; set; }
    public int TemplateId { get; set; }
    public byte[] Content { get; set; }
    public int SignId { get; set; }
    
    
    // public DocumentSingInfo DocumentSingInfo { get; set; }
    // public VacationsApplication VacationsApplication { get; set; }
    // public VacationApplicationType VacationApplicationType { get; set; }
    // public TemplateType TemplateType { get; set; }
}