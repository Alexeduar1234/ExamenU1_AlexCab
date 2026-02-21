using System.ComponentModel.DataAnnotations;

namespace ExamU1Alex.Entities
{
    public class PasswordRequest
    {
        public string Password { get; set; } = string.Empty;
    }

    public class RequisitosResponse
    {
        public bool LongitudMinima { get; set; }
        public bool TieneMayuscula { get; set; }
        public bool TieneMinuscula { get; set; }
        public bool TieneNumero { get; set; }
        public bool TieneEspecial { get; set; }
    }

    public class PasswordValidationResponse
    {
        public bool EsValida { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public RequisitosResponse Requisitos { get; set; } = new RequisitosResponse();
    }
}
