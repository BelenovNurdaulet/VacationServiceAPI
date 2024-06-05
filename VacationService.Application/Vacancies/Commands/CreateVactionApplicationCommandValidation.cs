using FluentValidation;
using MediatR;
using VacationService.Domain.Entities;

namespace VacationService.Application.Vacancies.Commands;

public class CreateVactionApplicationCommandValidation : AbstractValidator<CreateVacationApplicationCommand>
{
    public CreateVactionApplicationCommandValidation()
    {

        RuleFor(c => c.CreateBy).Must(x => x > 0).WithMessage("Not Null");
        
        RuleFor(c => c.StartDate)
            .NotEmpty().WithMessage("Start date must be provided.")
            .LessThan(c => c.EndDate)
            .WithMessage("Start date must be before end date.");
        
        RuleFor(c => c.EndDate)
            .NotEmpty().WithMessage("End date must be provided.")
            .GreaterThan(c => c.StartDate)
            .WithMessage("End date must be after start date.");

    }

}