using System.ComponentModel.DataAnnotations;

namespace Animes.Data.Dtos
{
    public class ReadAnimeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public string Genero { get; set; }


        [Required(ErrorMessage = "O campo Autor é obrigatório")]
        public string Autor { get; set; }


        [Required(ErrorMessage = "O campo NúmeroEpisodios é obrigatório")]
        public int NumeroEpisodios { get; set; }


        [Required(ErrorMessage = "O campo Resumo é obrigatório")]
        public string Resumo { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
