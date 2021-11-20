using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers;

[ApiController]
[Route("[controller]")]
public class GreetService4 : ControllerBase
{
    private readonly IGreetServiceLib _lib;

    public GreetService4(IGreetServiceLib lib)
    {
        _lib = lib;
    }

    [HttpGet]
    public ActionResult<string> GetGreet4Message(string name)
    {
        string msg = _lib.GetGreetMessage(name, 4);
        return Ok(msg);
    }
}