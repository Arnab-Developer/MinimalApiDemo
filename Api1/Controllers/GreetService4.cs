using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers;

[ApiController]
[Route("[controller]")]
public class GreetService4 : ControllerBase
{
    [HttpGet]
    public ActionResult<string> GetGreet4Message(string name) =>
        Ok($"Hello {name}, this is greet 4 service.");
}