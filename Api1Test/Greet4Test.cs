using Api1.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Api1Test;

public class Greet4Test
{
    [Fact]
    public void HappyPathTest()
    {
        GreetService4 greetService4 = new();
        ActionResult<string> ar = greetService4.GetGreet4Message("Test user");
        Assert.NotNull(ar);
        OkObjectResult okResult = (OkObjectResult)ar.Result!;
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
        Assert.Equal("Hello Test user, this is greet 4 service.", okResult.Value);
    }
}