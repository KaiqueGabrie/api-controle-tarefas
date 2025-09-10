using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIservico.Models.Dtos;
using APIservico.Models;

namespace APIservico.Controllers
{
    [Route("/chamados")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {
        private static List<Chamado> _listaChamados = new List<Chamado>
        {
            new Chamado() {Id = 1, Titulo = "Erro na Tela de Acesso", Descricao = "O usuário não conseguiu logar"},
            new Chamado() {Id = 2, Titulo = "Sistema com lentidão", Descricao = "Demora no carregamento das telas"}
        };

        private static int _proximoId = 3;

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            return Ok(_listaChamados);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var chamado = _listaChamados.FirstOrDefault(x => x.Id == id);// busca o chamado do id, ou se não houver retorna nulo.
            if (chamado == null)
            {
                return NotFound();
            }
            return Ok(chamado); // se não for nulo, vai retornar o chamado por completo.
        }

        [HttpPost]
        public IActionResult Criar([FromBody] ChamadoDto novoChamado) // criado o chamadoDto somente para não puxar id e status, puxar apenas titulo e descrição.
        {
            var chamado = new Chamado() { Titulo = novoChamado.Titulo, Descricao = novoChamado.Descricao };

            chamado.Id = _proximoId++;
            chamado.Status = "Aberto";
            _listaChamados.Add(chamado);
            return Created("", chamado);
        }
        [HttpPut("{id}")] // PUT Atualizar 
        public IActionResult Atualizar(int id, [FromBody] ChamadoDto novoChamado)
        {
            var chamado = _listaChamados.FirstOrDefault(x => x.Id == id);// busca o chamado do id, ou se não houver retorna nulo.
            if (chamado == null)
            {
                return NotFound();
            }
            chamado.Titulo = novoChamado.Titulo;
            chamado.Descricao = novoChamado.Descricao;
            chamado.Status = chamado.Status;

            return Ok(chamado); // se não for nulo, vai retornar o chamado por completo.
        }

        [HttpPut("{id}/Fechar-Chamado")]                                              
        public IActionResult FecharChamado(int id)
        {
            var chamado = _listaChamados.FirstOrDefault(x => x.Id == id);// busca o chamado do id, ou se não houver retorna nulo.
            if (chamado == null)
            {
                return NotFound();
            }
            chamado.Status = "Fechado";
            chamado.DataFechamento = DateTime.Now;

            return Ok(chamado.Status); // se não for nulo, vai retornar o chamado por completo.
        }


        [HttpDelete("{id}")] // Deletar
        public IActionResult Remover(int id)
        {
            var chamado = _listaChamados.FirstOrDefault(x => x.Id == id);// busca o chamado do id, ou se não houver retorna nulo.
            if (chamado == null)
            {
                return NotFound();
            }
            
            _listaChamados.Remove(chamado);

            return NoContent();
        }
    }
}
