using System;
using Microsoft.AspNetCore.Mvc;

namespace ExamU1Alex.Controllers
{
    [Route("api/salud")]
    [ApiController]
    public class ImcController : ControllerBase
    {
        [HttpGet("imc")]
        public IActionResult GetImc([FromQuery] double peso, [FromQuery] double altura)
        {
            if (peso <= 0)
                return BadRequest(new { Message = "El peso debe ser mayor que cero." });

            if (altura <= 0)
                return BadRequest(new { Message = "La altura debe ser mayor que cero." });

            double imc = peso / (altura * altura);
            double imcRounded = Math.Round(imc, 2);

            string clasificacion;
            if (imc < 18.5)
                clasificacion = "Bajo peso";
            else if (imc < 25.0)
                clasificacion = "Normal";
            else if (imc < 30.0)
                clasificacion = "Sobrepeso";
            else
                clasificacion = "Obesidad";

            return Ok(new
            {
                peso,
                altura,
                imc = imcRounded,
                clasificacion
            });
        }
    }
}

