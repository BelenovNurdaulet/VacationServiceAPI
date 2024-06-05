namespace VacationService.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public DateTime CreatedOn{ get; set; }
    public string CreateBy { get; set; }
    public int UserTypeId{ get; set; }
    public string FullName{ get; set; }
    public string ShortName{ get; set; }
    public string FirstName{ get; set; }
    public string Surname{ get; set; }
    public string Email{ get; set; }
    public string Login{ get; set; }
    public string PhoneNumber{ get; set; }
    public string IIN{ get; set; }

    
    // public ICollection<VacationsApplication> VacationsApplications { get; set;}

    

    
}