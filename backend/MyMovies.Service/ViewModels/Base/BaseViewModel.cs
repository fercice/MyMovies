using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Service.ViewModels
{
    public class BaseViewModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}
