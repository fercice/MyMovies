using System;
using System.Collections.Generic;
using System.Linq;
using MyMovies.Domain.Entities;

namespace MyMovies.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);        

        IList<TEntity> Select();

        TEntity SelectById(int id);

        IQueryable<TEntity> CreateQuery();

        int SaveChanges();
    }
}

