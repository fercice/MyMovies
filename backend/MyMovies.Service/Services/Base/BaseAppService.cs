using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using MyMovies.Domain.Entities;
using MyMovies.Domain.Exceptions;
using MyMovies.Domain.Interfaces;
using MyMovies.Service.Interfaces;
using MyMovies.Service.ViewModels;
using System.Linq;

namespace MyMovies.Service.Services
{
    public class BaseAppService<TEntity, VModel, Validator> 
        : IAppService<TEntity, VModel, Validator> where TEntity : Entity where VModel : BaseViewModel where Validator : AbstractValidator<TEntity>
    {
        private readonly IMapper mapper;
        private readonly IService<TEntity> service;

        public BaseAppService(IMapper mapper, IService<TEntity> service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        public virtual VModel InsertOrUpdate(VModel viewModel)
        {
            try
            {
                return (viewModel.Id == 0 ) ? Insert(viewModel) : Update(viewModel);
            }
            catch (ServiceException e)
            {
                throw new ServiceException(e.Message);
            }            
        }        

        public virtual void Delete(int id)
        {
            try
            {
                service.Delete(id);
            }
            catch (ServiceException e)
            {
                throw new ServiceException(e.Message);
            }            
        }

        public virtual IEnumerable<VModel> Select()
        {
            try
            {
                return mapper.Map<IEnumerable<TEntity>, IEnumerable<VModel>>(service.Select());
            }
            catch (ServiceException e)
            {
                throw new ServiceException(e.Message);
            }            
        }

        public virtual VModel SelectById(int id)
        {
            try
            {
                return mapper.Map<VModel>(service.SelectById(id));
            }
            catch (ServiceException e)
            {
                throw new ServiceException(e.Message);
            }            
        }

        public IQueryable<TEntity> CreateQuery() => service.CreateQuery();

        private VModel Insert(VModel viewModel)
        {
            try
            {
                var insertCommand = mapper.Map<TEntity>(viewModel);
                service.Insert<Validator>(insertCommand);

                return viewModel;
            }
            catch (ServiceException e)
            {
                throw new ServiceException(e.Message);
            }
        }

        private VModel Update(VModel viewModel)
        {
            try
            {
                var updateCommand = mapper.Map<TEntity>(viewModel);
                service.Update<Validator>(updateCommand);

                return viewModel;
            }
            catch (ServiceException e)
            {
                throw new ServiceException(e.Message);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
