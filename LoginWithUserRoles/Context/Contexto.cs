using LoginWithUserRoles.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoginWithUserRoles.Context;

public class Contexto : DbContext
{
	public Contexto(DbContextOptions<Contexto> options) : base(options) { }

	public DbSet<Usuarios> Usuarios { get; set; }
}
