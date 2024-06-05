using System.ComponentModel.DataAnnotations.Schema;

namespace VacationService.Domain.Entities;


// [Table(Vac.Status)]
public class VacationApplicationStatus
{
    public int Id { get; set; }
    public string Name{ get; set; }
    public string Description{ get; set; }
    
    // public VacationStatusHistory VacationStatusHistory{ get; set; }
    // public VacationsApplication VacationApplication { get; set; }
    
}

