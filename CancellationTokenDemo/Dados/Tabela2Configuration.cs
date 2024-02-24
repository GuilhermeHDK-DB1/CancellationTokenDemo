using CancellationTokenDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CancellationTokenDemo.Dados;

public class Tabela2Configuration : IEntityTypeConfiguration<Tabela2>
{
    public void Configure(EntityTypeBuilder<Tabela2> builder)
    {
        builder
            .ToTable("Tabela2");
        
        builder
            .Property(t => t.Id)
            .HasColumnName("id");

        builder
            .Property(t => t.QuantidadeCadastrada)
            .HasColumnName("quantidade_conta")
            .HasColumnType("int");
    }
}