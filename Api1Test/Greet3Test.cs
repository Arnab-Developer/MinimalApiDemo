namespace Api1Test;

public class Greet3Test
{
    private static HttpContext CreateMockHttpContext() =>
        new DefaultHttpContext
        {
            RequestServices = new ServiceCollection().AddLogging().BuildServiceProvider(),
            Response =
            {
                Body = new MemoryStream()
            },
        };

    [Fact]
    public async Task HappyPathTest()
    {
        Mock<IGreetServiceLib> greetServiceLibMock = new();
        greetServiceLibMock.Setup(s => s.GetGreetMessage("Test User", 3)).Returns("Test response");

        IGreetService3 greetService3 = new GreetService3(greetServiceLibMock.Object);
        IResult result = greetService3.GetGreet3Message("Test User");
        HttpContext mockHttpContext = CreateMockHttpContext();
        await result.ExecuteAsync(mockHttpContext);
        mockHttpContext.Response.Body.Position = 0;
        using StreamReader reader = new(mockHttpContext.Response.Body, Encoding.UTF8);

        Assert.Equal("\"Test response\"", reader.ReadToEnd());
        Assert.Equal(200, mockHttpContext.Response.StatusCode);
    }
}