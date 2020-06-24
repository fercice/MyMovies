using System;
using System.Collections.Generic;
using System.Linq;
using MyMovies.Domain.Entities;
using MyMovies.Domain.Interfaces;
using MyMovies.Infra.Data.Context;
using MyMovies.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;

namespace MyMovies.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly UnitOfWork unitOfWork;        
        protected readonly DbSet<TEntity> DbSet;

        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
            this.DbSet = context.Set<TEntity>();
        }

        protected MyMoviesContext context { get { return unitOfWork.context; } }
        protected MyMoviesContext newcontext = new MyMoviesContext();

        public void Insert(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Delete(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IList<TEntity> Select()
        {
            //return DbSet.ToList();

            return this.newcontext.Set<TEntity>().AsNoTracking().ToList();

        }

        public TEntity SelectById(int id)
        {
            //return DbSet.Find(id);

            return this.newcontext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> CreateQuery()
        {
            return this.newcontext.Set<TEntity>().AsNoTracking();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
