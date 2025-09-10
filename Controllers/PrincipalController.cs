using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIservico.Controllers
{
    [Route("/")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {

        [HttpGet("situacao")]
        public IActionResult Principal() 
        {
            var resultado = new { situacao = "Ok", mensagem = "Api Serviço" };
            return Ok(resultado);
        }
        [HttpGet("Autor")]
        public IActionResult Autor()
        {
            var resultado = new { nome = "Kaique", telefone = "(69) 992027086", email = "gkaique39@gmail.com" };
            return Ok(resultado);
        }

    }
}
