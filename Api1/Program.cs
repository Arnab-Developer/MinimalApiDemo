WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IGreetServiceLib, GreetServiceLib>();
builder.Services.AddTransient<IGreetService3, GreetService3>();

WebApplication app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.MapControllers();
app.MapGet("greet1", (string name, IGreetServiceLib lib) =>
{
    string msg = lib.GetGreetMessage(name, 1);
    return Results.Ok(msg);
});
app.MapGreetService2();
IGreetService3 greetService3 = app.Services.GetRequiredService<IGreetService3>();
greetService3.Register(app);

app.Run();