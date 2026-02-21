using System;
using System.ComponentModel.DataAnnotations;

namespace ExamU1Alex.Entities
{
    public class ImcRequest
    {
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "El peso debe ser mayor que cero.")]
        public double Peso { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "La altura debe ser mayor que cero.")]
        public double Altura { get; set; }
    }

    public class ImcResponse
    {
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Imc { get; set; }
        public string Clasificacion { get; set; } = string.Empty;
    }
    
}
