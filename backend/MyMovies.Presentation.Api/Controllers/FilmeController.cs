using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MyMovies.Domain.Interfaces;
using MyMovies.Presentation.Api.Extensions;
using MyMovies.Presentation.Api.ViewModels;
using MyMovies.Service.Interfaces;
using MyMovies.Service.ViewModels;
using MyMovies.Domain.Exceptions;
using MyMovies.Domain.Messages;
using MyMovies.Domain.Security;

namespace MyMovies.Presentation.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/filme")]
    public class FilmeController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IFilmeAppService appFilmeService;

        public FilmeController(IUnitOfWork unitOfWork,
                               IMapper mapper,
                               IFilmeAppService appFilmeService) : base(unitOfWork)
        {
            this.mapper = mapper;
            this.appFilmeService = appFilmeService;
        }

        [HttpGet()]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            try
            {
                var viewModel = appFilmeService.SelectLazyload();

                return Ok(new ResponseViewModel(viewModel));
            }
            catch (ServiceException e)
            {
                return StatusCode(HttpStatusCode.OK.ToInt(), new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    ErrorMessage = e.Message
                });

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.ToInt(), new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {
            try
            {
                var result = appFilmeService.ObterFilmesPorId(id);

                return Ok(new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = result,
                    OkMessage = Messaging.MessageDeletedOk
                });
            }
            catch (ServiceException e)
            {
                return StatusCode(HttpStatusCode.OK.ToInt(), new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    ErrorMessage = e.Message
                });

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.ToInt(), new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpPost()]
        public async Task<ActionResult<dynamic>> Create([FromBody]FilmeSaveViewModel viewModel)
        {
            List<string> Erros = new List<string>();

            try
            {
                // Validações
                if (!ModelState.IsValid)
                {
                    foreach (var modelStateVal in ViewData.ModelState.Values)
                        foreach (var error in modelStateVal.Errors)
                            Erros.Add(error.ErrorMessage);

                    return StatusCode(HttpStatusCode.BadRequest.ToInt(), new ResponseViewModel()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                        Data = Erros,
                        ErrorMessage = Messaging.MessageRequiredFields
                    });
                }

                // Salcar no BD
                var diretorService = mapper.Map<FilmeViewModel>(viewModel);
                var result = appFilmeService.InsertOrUpdate(diretorService);
                if (result == null)
                    throw new ServiceException(Messaging.MessageServiceError + Messaging.MessageSavedError);

                if (!IsValidOperation())
                    throw new ServiceException(Messaging.MessageRepositoryError + Messaging.MessageSavedError);

                return Ok(new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = result,
                    OkMessage = Messaging.MessageSavedOk
                });
            }
            catch (ServiceException e)
            {
                return StatusCode(HttpStatusCode.OK.ToInt(), new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    ErrorMessage = e.Message
                });

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.ToInt(), new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<dynamic>> Update(int id, [FromBody]FilmeSaveViewModel viewModel)
        {
            List<string> Erros = new List<string>();

            try
            {
                // Validações
                if (!ModelState.IsValid)
                {
                    foreach (var modelStateVal in ViewData.ModelState.Values)
                        foreach (var error in modelStateVal.Errors)
                            Erros.Add(error.ErrorMessage);

                    return StatusCode(HttpStatusCode.BadRequest.ToInt(), new ResponseViewModel()
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                        Data = Erros,
                        ErrorMessage = Messaging.MessageRequiredFields
                    });
                }

                var diretorService = appFilmeService.SelectById(id);
                if (diretorService == null)
                    throw new ServiceException(Messaging.MessageNoRecord);
                else
                    diretorService = mapper.Map<FilmeViewModel>(viewModel);

                diretorService.Id = id;

                // Salcar no BD                     
                var result = appFilmeService.InsertOrUpdate(diretorService);
                if (result == null)
                    throw new ServiceException(Messaging.MessageServiceError + Messaging.MessageSavedError);

                if (!IsValidOperation())
                    throw new ServiceException(Messaging.MessageRepositoryError + Messaging.MessageSavedError);

                return Ok(new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Data = result,
                    OkMessage = Messaging.MessageSavedOk
                });
            }
            catch (ServiceException e)
            {
                return StatusCode(HttpStatusCode.OK.ToInt(), new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    ErrorMessage = e.Message
                });

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.ToInt(), new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<dynamic>> Delete(int id)
        {
            try
            {
                appFilmeService.Delete(id);

                if (!IsValidOperation())
                    throw new ServiceException(Messaging.MessageRepositoryError + Messaging.MessageDeletedError);

                return Ok(new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    OkMessage = Messaging.MessageDeletedOk
                });
            }
            catch (ServiceException e)
            {
                return StatusCode(HttpStatusCode.OK.ToInt(), new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    ErrorMessage = e.Message
                });

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.ToInt(), new ResponseViewModel()
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}
