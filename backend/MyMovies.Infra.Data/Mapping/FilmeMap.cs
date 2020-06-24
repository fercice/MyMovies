using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using MyMovies.Domain.Entities;

namespace MyMovies.Infra.Data.Mapping
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Elenco)
                .IsRequired();

            builder.Property(c => c.Sinopse)
                .IsRequired();

            builder.HasOne(x => x.Diretor)
                   .WithMany(x => x.Filmes);

            builder.HasOne(x => x.Genero)
                   .WithMany(x => x.Filmes);
        }
    }
}
