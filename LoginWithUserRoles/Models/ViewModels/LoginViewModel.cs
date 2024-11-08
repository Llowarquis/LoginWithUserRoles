using System.ComponentModel.DataAnnotations;

namespace LoginWithUserRoles.Models.ViewModels;

public class LoginViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, Introduzca el Nombre de Usuario")]
    public string? Username { get; set; }


    [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, Introduzca la Contraseña")]
    public string? Password { get; set; }
}
