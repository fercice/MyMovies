using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Presentation.Api.Extensions;
using MyMovies.Presentation.Api.ViewModels;

namespace MyMovies.Presentation.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/test")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        [HttpGet()]
        [Route("anonymous")]
        [AllowAnonymous]
        public ActionResult Anonymous()
        {
            try
            {
                return Ok(new ResponseViewModel());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseViewModel(ex.Message));
            }
        }

        [HttpGet()]
        [Route("basic")]
        [Authorize(AuthenticationSchemes = "Basic")]
        public ActionResult Basic()
        {
            try
            {
                return Ok(new ResponseViewModel());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseViewModel(ex.Message));
            }
        }

        [HttpGet()]
        [Route("bearer")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public ActionResult Bearer()
        {
            try
            {
                return Ok(new ResponseViewModel());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseViewModel(ex.Message));
            }
        }

        [HttpGet()]
        [Route("authenticated")]
        [Authorize()]        
        public ActionResult Authenticated()
        {
            try
            {
                return Ok(new ResponseViewModel());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseViewModel(ex.Message));
            }
        }
    }
}
