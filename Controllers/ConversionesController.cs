using System;
using Microsoft.AspNetCore.Mvc;

namespace ExamU1Alex.Controllers
{
    [Route("api/conversiones")]
    [ApiController]
    public class ConversionesController : ControllerBase
    {
        [HttpGet("temperatura")]
        public IActionResult Temperatura([FromQuery] double valor, [FromQuery] string de, [FromQuery] string a)
        {
            if (string.IsNullOrWhiteSpace(de) || string.IsNullOrWhiteSpace(a))
                return BadRequest(new { Message = "Se requieren los parámetros 'de' y 'a' con valores C, F o K." });

            string origen = de.Trim().ToUpperInvariant();
            string destino = a.Trim().ToUpperInvariant();

            bool EsEscalaValida(string s) => s == "C" || s == "F" || s == "K";

            if (!EsEscalaValida(origen) || !EsEscalaValida(destino))
                return BadRequest(new { Message = "Escalas inválidas. Use C, F o K." });

            double ToCelsius(double v, string escala)
            {
                return escala switch
                {
                    "C" => v,
                    "F" => (v - 32.0) * 5.0 / 9.0,
                    "K" => v - 273.15,
                    _ => throw new ArgumentException("Escala inválida")
                };
            }

            double FromCelsius(double c, string escala)
            {
                return escala switch
                {
                    "C" => c,
                    "F" => (c * 9.0 / 5.0) + 32.0,
                    "K" => c + 273.15,
                    _ => throw new ArgumentException("Escala inválida")
                };
            }

            double celsius = ToCelsius(valor, origen);
            double convertido = FromCelsius(celsius, destino);

            string NombreEscala(string s) => s switch
            {
                "C" => "Celsius",
                "F" => "Fahrenheit",
                "K" => "Kelvin",
                _ => s
            };

            var resp = new
            {
                valorOriginal = valor,
                escalaOriginal = NombreEscala(origen),
                valorConvertido = Math.Round(convertido, 2),
                escalaDestino = NombreEscala(destino)
            };

            return Ok(resp);
        }
    }
}
