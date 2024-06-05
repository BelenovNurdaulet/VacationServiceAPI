using System.ComponentModel.DataAnnotations.Schema;

namespace VacationService.Domain.Entities
{
	public class VacationStatusHistory
	{
		public int Id { get; set; }

		public DateTime CreatedOn { get; set; }
		public int CreateBy { get; set; }
		public int ApplicationId { get; set; }
		public int OldStatusId { get; set; }
		public int NewStatusId { get; set; }

		public string Comments { get; set; }
		public DateTime ResponseTime { get; set; }
		public TimeSpan IdleTime { get; set; }


		// public VacationApplicationStatus  VacationApplicationStatusOld {get; set;}
		// public VacationApplicationStatus  VacationApplicationStatusNew {get; set;}

	public VacationsApplication VacationsApplication { get; set; }
	}
}

