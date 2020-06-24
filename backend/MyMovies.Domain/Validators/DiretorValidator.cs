using FluentValidation;
using System;
using MyMovies.Domain.Entities;

namespace MyMovies.Domain.Validators
{
    public class DiretorValidator : AbstractValidator<Diretor>
    {
        public DiretorValidator()
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