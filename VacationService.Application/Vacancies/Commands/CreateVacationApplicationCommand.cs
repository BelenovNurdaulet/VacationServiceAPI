using KDS.Primitives.FluentResult;
using MediatR;
using VacationService.Domain.Entities;

namespace VacationService.Application.Vacancies.Commands
{
    public class CreateVacationApplicationCommand :  IRequest<Result<VacationsApplication>>
    {

        public CreateVacationApplicationCommand(
            int createBy, 
            DateTime startDate, 
            DateTime endDate, 
            int applicationTypeId)
            // int oldStatusId, 
            // int newStatusId, 
            // string comments, 
            // DateTime responseTime, 
            // TimeSpan idleTime
        {
            CreateBy = createBy;
            StartDate = startDate;
            EndDate = endDate;
            ApplicationTypeId = applicationTypeId;
        }
        
        public int CreateBy{ get; }
        public DateTime StartDate{ get; }
        public DateTime EndDate { get; }
        public int ApplicationTypeId { get;  }
        

   
    }
    
}