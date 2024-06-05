namespace VacationServiceAPI.Contracts.Requests;

public record CreateVacationApplicationRequest(
    int CreateBy,
    DateTime StartDate,
    DateTime EndDate,
    int ApplicationTypeId);