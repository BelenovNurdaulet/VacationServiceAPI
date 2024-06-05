using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KDS.Primitives.FluentResult;
using MediatR;
using VacationService.Application.Interfaces;
using VacationService.Domain.Entities;
using VacationService.Application.Vacancies.Queries;

namespace VacationService.Application.Vacancies.Queries
{
    public class GetVacationApplicationsQueryHandler : IRequestHandler<GetVacationApplicationsQuery, Result<List<VacationsApplication>>>
    {
        private readonly IDataContext _dataContext;
        private readonly ILogger<GetVacationApplicationsQueryHandler> _logger;

        public GetVacationApplicationsQueryHandler(IDataContext dataContext, ILogger<GetVacationApplicationsQueryHandler> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<Result<List<VacationsApplication>>> Handle(GetVacationApplicationsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start query");

            var vacations = await _dataContext.VacationsApplications
                .Where(x => x.CreateBy == request.CreateBy)
                .ToListAsync(cancellationToken);

            _logger.LogInformation("End query");

            return Result.Success(vacations);
        }
    }
}