using FluentValidation;
using System;
using System.Linq;
using System.Collections.Generic;
using MyMovies.Domain.Entities;
using MyMovies.Domain.Interfaces;

namespace MyMovies.Service.Services
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : Entity
    {
        private readonly IRepository<TEntity> repository;

        public BaseService(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public TEntity Insert<V>(TEntity obj) where V : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public TEntity Update<V>(TEntity obj) where V : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id não pode ser nulo.");

            repository.Delete(id);
        }

        public IList<TEntity> Select() => repository.Select();

        public TEntity SelectById(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id não pode ser nulo.");

            return repository.SelectById(id);
        }

        public IQueryable<TEntity> CreateQuery() => repository.CreateQuery();

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
