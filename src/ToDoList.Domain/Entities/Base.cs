namespace ToDoList.Domain.Entities;

public abstract class Base
{
    public long Id { get; set; }
    internal List<string> _errors;

    public Base()
    {
        _errors = new List<string>();
    }

    public IReadOnlyCollection<string> Errors => _errors;
}