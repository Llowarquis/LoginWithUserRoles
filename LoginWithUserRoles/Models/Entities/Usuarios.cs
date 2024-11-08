using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginWithUserRoles.Models.Entities;

public class Usuarios
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int UsuarioId { get; set; }


	[MaxLength(25)]
    public string? Username { get; set; }


	[MaxLength(64)]
    public string? Password { get; set; }


    [MaxLength(20)]
    public string? Rol { get; set; }
}
