namespace VacationService.Domain.Entities;

public class DocumentTemplate
{
    public int Id { get; set; }
    public DateTime CreatedOn{ get; set; }
    public string CreateBy{ get; set; }
    public string TemplateName{ get; set; }
    public string Description{ get; set; }
    public byte[] TemplateContent{ get; set; }
    public int TemplateTypeId{ get; set; }
    
    // public TemplateType TemplateType { get; set; }

}