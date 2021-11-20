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
        IGreetService3 greetService3 = new GreetService3();
        IResult result = greetService3.GetGreet3Message("Test user");
        HttpContext mockHttpContext = CreateMockHttpContext();
        await result.ExecuteAsync(mockHttpContext);
        mockHttpContext.Response.Body.Position = 0;
        using StreamReader reader = new(mockHttpContext.Response.Body, Encoding.UTF8);

        Assert.Equal("\"Hello Test user, this is greet 3 service.\"", reader.ReadToEnd());
        Assert.Equal(200, mockHttpContext.Response.StatusCode);
    }
}