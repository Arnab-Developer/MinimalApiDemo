namespace Lib1Test;

public class Lib1Test
{
    [Fact]
    public void Can_GetGreetMessage_ReturnProperMessage()
    {
        IGreetServiceLib greetServiceLib = new GreetServiceLib();
        string msg = greetServiceLib.GetGreetMessage("Jon Doe", 10);
        Assert.Equal("Hello Jon Doe, this is greet 10 service.", msg);
    }
}