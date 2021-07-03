using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("soma/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Soma(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var resultado = ConvertToDecimal(primeiroNumero) + ConvertToDecimal(segundoNumero);
                return Ok(resultado.ToString());
            }

            return BadRequest("Entrada Inválida");
        }

        [HttpGet("subtracao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Subtracao(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var resultado = ConvertToDecimal(primeiroNumero) - ConvertToDecimal(segundoNumero);
                return Ok(resultado.ToString());
            }

            return BadRequest("Entrada Inválida");
        }

        [HttpGet("multiplicacao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Multiplicacao(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var resultado = ConvertToDecimal(primeiroNumero) * ConvertToDecimal(segundoNumero);
                return Ok(resultado.ToString());
            }

            return BadRequest("Entrada Inválida");
        }

        [HttpGet("divisao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Divisao(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                if (segundoNumero != "0")
                {
                    var resultado = ConvertToDecimal(primeiroNumero) / ConvertToDecimal(segundoNumero);
                    return Ok(resultado.ToString());
                }
            }

            return BadRequest("Entrada Inválida");
        }

        [HttpGet("media/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Media(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                if (segundoNumero != "0")
                {
                    var resultado = ConvertToDecimal(primeiroNumero) / ConvertToDecimal(segundoNumero);
                    return Ok(resultado.ToString());
                }
            }

            return BadRequest("Entrada Inválida");
        }

        [HttpGet("raiz/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Raiz(string primeiroNumero)
        {
            if (IsNumeric(primeiroNumero))
            {
                var resultado = Math.Sqrt((double)ConvertToDecimal(primeiroNumero));
                return Ok(resultado.ToString());
            }

            return BadRequest("Entrada Inválida");
        }

        private bool IsNumeric(string strNumero)
        {
            return double.TryParse(strNumero, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out double numero);
        }

        private decimal ConvertToDecimal(string strNumero)
        {
            return decimal.TryParse(strNumero, out decimal resultado) ? resultado : 0;
        }

    }
}
