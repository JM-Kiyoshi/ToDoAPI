namespace ToDoList.API.VIewModel;

public class ResultViewModel
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public dynamic Data { get; set; }
}