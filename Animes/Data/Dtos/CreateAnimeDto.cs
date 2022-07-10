using System.ComponentModel.DataAnnotations;

namespace Animes.Data.Dtos
{
    public class CreateAnimeDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public string Genero { get; set; }


        [Required(ErrorMessage = "O campo Autor é obrigatório")]
        public string Autor { get; set; }


        [Required(ErrorMessage = "O campo Número de Episodios é obrigatório")]
        public int Episodios { get; set; }

        [Required(ErrorMessage = "O campo Resumo é obrigatório")]
        public string Resumo { get; set; }

    }
}
