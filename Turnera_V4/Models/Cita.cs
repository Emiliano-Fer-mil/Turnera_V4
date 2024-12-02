using System.ComponentModel;

namespace Turnera_V4.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El médico es obligatorio")]
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        [Required(ErrorMessage = "la fecha y hora son obligatorias")]
        [Display(Name = "Fecha | Hora")]
        [DisplayFormat(DataFormatString = "{0:dd/MM} | {0: HH:mm}", ApplyFormatInEditMode = true)]
        [RestringirDiasYHorarios(ErrorMessage = "Las citas pueden agendarse de l a v de 10 a 16 hs.")]
        public DateTime FechaHora { get; set; }

        public int? AsociadoId { get; set; }
        public Asociado? Asociado { get; set; }

        public bool EstaOcupado => Asociado != null;


    }
}
