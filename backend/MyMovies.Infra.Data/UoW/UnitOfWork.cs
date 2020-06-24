using MyMovies.Domain.Interfaces;
using MyMovies.Infra.Data.Context;

namespace MyMovies.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public MyMoviesContext context;

        public UnitOfWork(MyMoviesContext context)
        {
            this.context = context;
        }

        public bool Commit()
        {
            return context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
