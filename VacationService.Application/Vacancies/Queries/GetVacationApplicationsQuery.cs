using KDS.Primitives.FluentResult;
using MediatR;
using VacationService.Domain.Entities;

namespace VacationService.Application.Vacancies.Queries;

public class GetVacationApplicationsQuery : IRequest<Result<List<VacationsApplication>>>, IRequest<Result<VacationsApplication>>
{
    public int CreateBy { get; }

    public GetVacationApplicationsQuery(int createBy)
    {
        CreateBy = createBy;
    }
}