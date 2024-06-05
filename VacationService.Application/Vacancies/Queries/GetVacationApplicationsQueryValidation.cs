using System.Data;
using FluentValidation;
// using VacationService.Domain.Enums;

namespace VacationService.Application.Vacancies.Queries;

public class GetVacationApplicationsQueryValidation : AbstractValidator<GetVacationApplicationsQuery>
{
    public GetVacationApplicationsQueryValidation()
    {
        RuleFor(x => x.CreateBy)
            .Must(x => x > 0)
            .WithMessage("Id incorrect");
    }
}