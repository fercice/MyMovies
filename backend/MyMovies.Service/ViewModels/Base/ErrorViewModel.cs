using System;

namespace MyMovies.Service.ViewModels
{
    public class ErrorViewModel : BaseViewModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}
