using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<Person> Pessoas { get; set; }
    public DbSet<Contract> Contratos { get; set; }

    protected void OnModelCreating(ModelBuilder builder){
        builder.Entity<Person>(tabela =>{
            tabela.HasKey(e => e.Id);
            tabela  
                .HasMany(e => e.Contratos)
                .WithOne()
                .HasForeignKey(c => c.PessoaId);
            
        });

        builder.Entity<Contract>(tabela =>{
            tabela.HasKey(e => e.Id);
        });
    }
}