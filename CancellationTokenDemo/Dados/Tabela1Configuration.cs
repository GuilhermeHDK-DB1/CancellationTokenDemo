using CancellationTokenDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CancellationTokenDemo.Dados;

public class Tabela1Configuration : IEntityTypeConfiguration<Tabela1>
{
    public void Configure(EntityTypeBuilder<Tabela1> builder)
    {
        builder
            .ToTable("Tabela1");
        
        builder
            .Property(t => t.Id)
            .HasColumnName("id");

        builder
            .Property(t => t.UserName)
            .HasColumnName("username")
            .HasColumnType("varchar(100)");
    }
}