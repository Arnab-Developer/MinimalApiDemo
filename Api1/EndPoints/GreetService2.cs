namespace Api1.EndPoints;

public static class GreetService2
{
    public static void MapGreetService2(this IEndpointRouteBuilder app) =>
        app.MapGet("greet2", GetGreet2Message);

    public static IResult GetGreet2Message(string name) =>
        Results.Ok($"Hello {name}, this is greet 2 service.");
}