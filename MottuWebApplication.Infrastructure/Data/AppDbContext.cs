using Microsoft.EntityFrameworkCore;
using MottuWebApplication.Domain.Entities;
using MottuWebApplication.MottuWebApplication.Domain.Entities;
namespace MottuWebApplication.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Logradouro> Logradouros { get; set; }
    public DbSet<Bairro> Bairros { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Filial> Filiais { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<FilialDepartamento> FilialDepartamentos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Modelo> Modelos { get; set; }
    public DbSet<Moto> Motos { get; set; }
    public DbSet<Manutencao> Manutencoes { get; set; }
    public DbSet<Review> Reviews { get; set; }


}
