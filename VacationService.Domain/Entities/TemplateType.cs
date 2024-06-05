namespace VacationService.Domain.Entities;

public class TemplateType
{
    public int Id { get; set; }
    public string Name{ get; set; }
    public string Description{ get; set; }
    
    // public ICollection<DocumentTemplate> DocumentTemplates { get; set; }
    // public Document Document { get; set; }
}