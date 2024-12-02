namespace Turnera_V4.Models
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40,ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(8, MinimumLength =8, ErrorMessage = "el DNI debe tener 8 dígitos")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "solo dígitos")]
        public string Documento { get; set; }

        [Required]
        public  Especialidad Especialidad { get; set; }

        public List<Cita> Citas { get; set; } = new List<Cita>();

    }
}
