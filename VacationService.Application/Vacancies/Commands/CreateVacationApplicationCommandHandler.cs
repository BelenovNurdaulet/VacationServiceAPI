using MediatR;
using KDS.Primitives.FluentResult;
using VacationService.Domain.Entities;
using VacationService.Application.Interfaces;
using Microsoft.Extensions.Logging;


namespace VacationService.Application.Vacancies.Commands
{
    public class CreateVacationApplicationCommandHandler : IRequestHandler<CreateVacationApplicationCommand, Result<VacationsApplication>>
    {
        private readonly IDataContext _dataContext;
        private readonly ILogger<CreateVacationApplicationCommandHandler> _logger;

        public CreateVacationApplicationCommandHandler(IDataContext dataContext, ILogger<CreateVacationApplicationCommandHandler> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<Result<VacationsApplication>> Handle(CreateVacationApplicationCommand request, CancellationToken cancellationToken)
        {       
            _logger.LogInformation("Start command");
            if (request.StartDate.Date == request.EndDate.Date)
            {
                return Result.Failure<VacationsApplication>(new Error("400", "Wrong input"));
            }

            //Проверка состояний заявок на одну дату
            //15-20 16-19
            int totalDays = (request.EndDate - request.StartDate).Days;
            
                var vacationApplication = new VacationsApplication
                {
                    ApplicationGuid = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    CreateBy = request.CreateBy,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    ApplicationTypeId = request.ApplicationTypeId,
                    TotalDays = totalDays,
                    StatusId = 1,
                };

                await _dataContext.VacationsApplications.AddAsync(vacationApplication, cancellationToken);
                
                await _dataContext.SaveChangesAsync(cancellationToken);
                
                var vacationStatusHistory = new VacationStatusHistory
                {
                    CreatedOn = DateTime.Now,
                    CreateBy = request.CreateBy,
                    ApplicationId = vacationApplication.Id,
                    OldStatusId = 1,
                    NewStatusId = 2,
                    Comments = "Заявка создана",
                    ResponseTime = DateTime.Now,
                    IdleTime = TimeSpan.Zero,
                    
                    
                };
                await _dataContext.VacationStatusHistories.AddAsync(vacationStatusHistory, cancellationToken);
                await _dataContext.SaveChangesAsync(cancellationToken);

                _logger.LogInformation("End Command");
                return Result.Success(vacationApplication);

          
        }
    }
}
