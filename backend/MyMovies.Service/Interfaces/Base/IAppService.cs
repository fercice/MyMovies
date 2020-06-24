using FluentValidation;
using System;
using System.Collections.Generic;
using MyMovies.Domain.Entities;
using MyMovies.Service.ViewModels;

namespace MyMovies.Service.Interfaces
{
    public interface IAppService<TEntity, VModel, Validator>
        where TEntity : Entity
        where VModel : BaseViewModel 
        where Validator : AbstractValidator<TEntity>
    {
        VModel InsertOrUpdate(VModel vmodel);        

        void Delete(int id);

        IEnumerable<VModel> Select();

        VModel SelectById(int id);
    }
}

