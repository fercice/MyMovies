using FluentValidation;
using System;
using MyMovies.Domain.Entities;

namespace MyMovies.Domain.Validators
{
    public class GeneroValidator : AbstractValidator<Genero>
    {
        public GeneroValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Nenhum dado encontrado.");
                });

            RuleFor(c => c.Nome)
                .NotEmpty().NotNull().WithMessage("Nome é obrigatório.");
        }
    }
}