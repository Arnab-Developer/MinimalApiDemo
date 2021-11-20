namespace Api1.EndPoints;

public interface IGreetService3
{
    public void Register(IEndpointRouteBuilder app);

    public IResult GetGreet3Message(string name);
}