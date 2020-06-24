using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Service.ViewModels
{
    public class GeneroSaveViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
    }
}
