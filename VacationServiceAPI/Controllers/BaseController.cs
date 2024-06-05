using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VacationServiceAPI.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    public ISender Sender => HttpContext.RequestServices.GetRequiredService<ISender>();
    
}