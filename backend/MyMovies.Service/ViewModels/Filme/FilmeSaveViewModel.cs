using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Service.ViewModels
{
    public class FilmeSaveViewModel
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

        [Required(ErrorMessage = "Diretor é obrigatório")]
        public int DiretorId { get; set; }

        [Required(ErrorMessage = "Genero é obrigatório")]
        public int GeneroId { get; set; }
    }
}
