using Api1.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Api1Test;

public class Greet4Test
{
    [Fact]
    public void HappyPathTest()
    {
        Mock<IGreetServiceLib> greetServiceLibMock = new();
        greetServiceLibMock.Setup(s => s.GetGreetMessage("Test User", 4)).Returns("Test response");

        GreetService4 greetService4 = new(greetServiceLibMock.Object);
        ActionResult<string> ar = greetService4.GetGreet4Message("Test User");
        Assert.NotNull(ar);
        OkObjectResult okResult = (OkObjectResult)ar.Result!;
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
        Assert.Equal("Test response", okResult.Value);
    }
}