using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/traffic-report")]
public class LoggingController : ControllerBase
{
    private readonly ILoggerRepository _loggerRepository;

    public LoggingController(ILoggerRepository loggerRepository)
    {
        _loggerRepository = loggerRepository;
    }

    [HttpGet]
    public IEnumerable<RequestLog> ListLoggs()
    {
        return _loggerRepository.GetAllLoggs(); 
    }
}
