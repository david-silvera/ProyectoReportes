using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoApi.Models
{
    public class Noticia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]

        public int UsuarioId { get; set; }
        [Required]
        [MaxLength(100)]

        public string Lugar { get; set; }
        [Required]
        [MaxLength(100)]
        public string Ciudad { get; set; }
        [Required]
        [MaxLength(250)]

        public string DescripcionBreve { get; set; }
        [Required]
        public string DescripcionAmpliada { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        [Required]
        public string Imagen { get; set; }
    }
}
