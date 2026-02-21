using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ExamU1Alex.Controllers
{
    [Route("api/matematicas")]
    [ApiController]
    public class MatematicasController : ControllerBase
    {
        [HttpGet("tabla/{numero}")]
        public IActionResult Tabla([FromRoute] int numero, [FromQuery] int? hasta)
        {
            int limite = (hasta.HasValue && hasta.Value > 0) ? hasta.Value : 10;

            var tabla = new List<string>();
            for (int i = 1; i <= limite; i++)
            {
                tabla.Add($"{numero} x {i} = {numero * i}");
            }

            return Ok(new
            {
                numero = numero,
                hasta = limite,
                tabla = tabla
            });
        }
    }
}
