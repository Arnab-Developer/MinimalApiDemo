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
        IResult result = GreetService2.GetGreet2Message("Test user");
        HttpContext mockHttpContext = CreateMockHttpContext();
        await result.ExecuteAsync(mockHttpContext);
        mockHttpContext.Response.Body.Position = 0;
        using StreamReader reader = new(mockHttpContext.Response.Body, Encoding.UTF8);

        Assert.Equal("\"Hello Test user, this is greet 2 service.\"", reader.ReadToEnd());
        Assert.Equal(200, mockHttpContext.Response.StatusCode);
    }
}