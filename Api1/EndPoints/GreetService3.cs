namespace Api1.EndPoints;

public class GreetService3 : IGreetService3
{
    private readonly IGreetServiceLib _lib;

    public GreetService3(IGreetServiceLib lib)
    {
        _lib = lib;
    }

    public void Register(IEndpointRouteBuilder app) =>
        app.MapGet("greet3", GetGreet3Message);

    public IResult GetGreet3Message(string name)
    {
        string msg = _lib.GetGreetMessage(name, 3);
        return Results.Ok(msg);
    }
}