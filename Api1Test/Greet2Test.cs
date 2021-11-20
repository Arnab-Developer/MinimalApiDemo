namespace Api1Test;

public class Greet2Test
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
        greetServiceLibMock.Setup(s => s.GetGreetMessage("Test User", 2)).Returns("Test response");

        IResult result = GreetService2.GetGreet2Message("Test User", greetServiceLibMock.Object);
        HttpContext mockHttpContext = CreateMockHttpContext();
        await result.ExecuteAsync(mockHttpContext);
        mockHttpContext.Response.Body.Position = 0;
        using StreamReader reader = new(mockHttpContext.Response.Body, Encoding.UTF8);

        Assert.Equal("\"Test response\"", reader.ReadToEnd());
        Assert.Equal(200, mockHttpContext.Response.StatusCode);
    }
}