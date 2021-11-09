using System;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Exceptions.WebApi.Controllers;

[Route("api/[controller]")]
public class LogController : Controller
{
    [HttpPost("ok")]
    public IActionResult PostSampleData() => Ok(new { Result = "ok" });

    [HttpGet("exception")]
    public IActionResult GetByName() => throw new Exception("Não foi possível realizar o GetByName.");
}
