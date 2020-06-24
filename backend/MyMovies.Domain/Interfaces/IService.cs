using FluentValidation;
using System;
using System.Linq;
using System.Collections.Generic;
using MyMovies.Domain.Entities;

namespace MyMovies.Domain.Interfaces
{
    public interface IService<TEntity> where TEntity : Entity
    {
        TEntity Insert<V>(TEntity obj) where V : AbstractValidator<TEntity>;

        TEntity Update<V>(TEntity obj) where V : AbstractValidator<TEntity>;

        void Delete(int id);        

        IList<TEntity> Select();

        TEntity SelectById(int id);

        IQueryable<TEntity> CreateQuery();
    }
}
