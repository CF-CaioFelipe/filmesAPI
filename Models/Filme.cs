using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]  //Definindo que é a chave primaria
        [Required] //Definindo que é requirido
        public int Id { get; set; }

        [Required(ErrorMessage = "Precisa ter um Titúlo")]  //Error que precisa de Titulo
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Precisa ter um Diretor")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "Genêro deve ter no maximo 30 caractere")]  //Erro que precisa de 30 caracter 
        public string Genero { get; set; }

        [Range (1, 600 ,ErrorMessage = "Duração precisa ser entre 1 a 600 minutos")] //Erro, porque precisa ser entra 1 e 600
        public int Duracao { get; set; }
    }
}
