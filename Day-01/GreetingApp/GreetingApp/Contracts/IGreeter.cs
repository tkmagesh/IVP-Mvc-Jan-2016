namespace GreetingApp.Contracts
{
    public interface IGreeter
    {
        string Name { get; set; }
        string Greet();
    }
}