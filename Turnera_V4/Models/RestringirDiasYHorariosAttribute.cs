namespace Turnera_V4.Models
{
    public class RestringirDiasYHorariosAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationResult = ValidationResult.Success;
            var errores = new List<String>();

            if (value is not DateTime fechaHora)
            {
                errores.Add("el valor recibido no es Fecha y Hora");
            }
            else {
                
                if (fechaHora.DayOfWeek==DayOfWeek.Sunday || fechaHora.DayOfWeek == DayOfWeek.Saturday)
                {
                    errores.Add("ERROR: citas solo l. a v.");

                }
                var horaInicio = new TimeSpan(10, 0, 0);
                var horaFin = new TimeSpan(16, 0, 0);
                if (fechaHora.TimeOfDay < horaInicio || fechaHora.TimeOfDay > horaFin)
                {
                    errores.Add("ERROR: citas entre 10 y 16 hs.");
                }
                if (fechaHora > DateTime.Now.AddHours(2)) {
                    errores.Add("ERROR: cita al menos con dos horas de anticipación");
                }
                
            }
            if (errores.Count > 0)
            {
                validationResult = new ValidationResult(string.Join(" - ", errores));
            }
            return validationResult;
        }
    }
}
