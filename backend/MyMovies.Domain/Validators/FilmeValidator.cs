using FluentValidation;
using System;
using MyMovies.Domain.Entities;

namespace MyMovies.Domain.Validators
{
    public class FilmeValidator : AbstractValidator<Filme>
    {
        public FilmeValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Nenhum dado encontrado.");
                });

            RuleFor(c => c.Titulo)
                .NotEmpty().NotNull().WithMessage("Titulo é obrigatório.");

            RuleFor(c => c.Elenco)
                .NotEmpty().NotNull().WithMessage("Elenco é obrigatório.");

            RuleFor(c => c.Sinopse)
                .NotEmpty().NotNull().WithMessage("Sinopse é obrigatório.");

            RuleFor(c => c.DiretorId)
                .NotEmpty().NotNull().WithMessage("Diretor é obrigatório.");

            RuleFor(c => c.GeneroId)
                .NotEmpty().NotNull().WithMessage("Genero é obrigatório.");
        }
    }
}