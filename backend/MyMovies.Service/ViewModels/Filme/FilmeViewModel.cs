using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Service.ViewModels
{
    public class FilmeViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Titulo é obrigatório")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [DisplayName("Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Elenco é obrigatório")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]        
        [DisplayName("Elenco")]
        public string Elenco { get; set; }

        [Required(ErrorMessage = "Sinopse é obrigatório")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres")]
        [DisplayName("Sinopse")]
        public string Sinopse { get; set; }

        public DiretorViewModel Diretor { get; set; }

        public GeneroViewModel Genero { get; set; }

        public int DiretorId { get; set; }        

        public int GeneroId { get; set; }
    }
}
