using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using MyMovies.Domain.Interfaces;
using MyMovies.Presentation.Api.ViewModels;
using MyMovies.Presentation.Api.Extensions;
using System;
using System.IO;

namespace MyMovies.Presentation.Api.Controllers
{
    public class BaseController : Controller
    {        
        private IUnitOfWork unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {            
            this.unitOfWork = unitOfWork;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public bool IsValidOperation()
        {
            return unitOfWork.Commit();
        }
    }
}
