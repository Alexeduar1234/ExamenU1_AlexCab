using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using ExamU1Alex.Entities;

namespace ExamU1Alex.Controllers
{
    [Route("api/seguridad")]
    [ApiController]
    public class ValidadorController : ControllerBase
    {
        [HttpPost("validar-password")]
        public IActionResult ValidarPassword([FromBody] ExamU1Alex.Entities.PasswordRequest req)
        {
            if (req == null || string.IsNullOrEmpty(req.Password))
                return BadRequest(new { Message = "Request inválido. Se requiere 'password' en el body." });

            string pw = req.Password;

            bool longitud = pw.Length >= 8;
            bool tieneMayus = Regex.IsMatch(pw, "[A-Z]");
            bool tieneMinus = Regex.IsMatch(pw, "[a-z]");
            bool tieneNumero = Regex.IsMatch(pw, "[0-9]");
            bool tieneEspecial = Regex.IsMatch(pw, "[@#$%&*]");

            var requisitos = new ExamU1Alex.Entities.RequisitosResponse
            {
                LongitudMinima = longitud,
                TieneMayuscula = tieneMayus,
                TieneMinuscula = tieneMinus,
                TieneNumero = tieneNumero,
                TieneEspecial = tieneEspecial
            };

            bool esValida = longitud && tieneMayus && tieneMinus && tieneNumero && tieneEspecial;

            var resp = new ExamU1Alex.Entities.PasswordValidationResponse
            {
                EsValida = esValida,
                Mensaje = esValida ? "Contraseña segura" : "Contraseña no cumple requisitos",
                Requisitos = requisitos
            };

            return Ok(resp);
        }
    }
}