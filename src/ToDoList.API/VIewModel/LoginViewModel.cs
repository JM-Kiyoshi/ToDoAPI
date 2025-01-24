using System.ComponentModel.DataAnnotations;
namespace ToDoList.API.VIewModel;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email is required.")]
    public string Login { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}