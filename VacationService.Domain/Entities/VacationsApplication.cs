
namespace VacationService.Domain.Entities
{
	public class VacationsApplication
	{
		public int Id { get; set; }
		public Guid ApplicationGuid { get; set; }
		public DateTime CreatedOn { get; set; }
		
		public int CreateBy{ get; set; }
		
		public DateTime StartDate{ get; set; }
		public DateTime EndDate{ get; set; }
		
		public int TotalDays{ get; set; }
		public int StatusId{ get; set; }
		public int ApplicationTypeId{ get; set; }
		
		public User User{ get; set; }
		
		
		// public VacationApplicationType VacationApplicationType { get; set; }
		// public ICollection<Document> Documents { get; set; }
		public ICollection<VacationStatusHistory> VacationStatusHistories { get; set; }
		//
		// public VacationApplicationStatus VacationApplicationStatus { get; set; }
	}
}


