namespace Api1.EndPoints;

public class GreetService3 : IGreetService3
{
    public void Register(IEndpointRouteBuilder app) =>
        app.MapGet("greet3", GetGreet3Message);

    public IResult GetGreet3Message(string name) =>
        Results.Ok($"Hello {name}, this is greet 3 service.");
}