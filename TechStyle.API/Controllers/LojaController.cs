using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechStyle.API.DTO;
using TechStyle.Dados.Repositorio;
using TechStyle.Dominio.Modelo;

namespace TechStyle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LojaController : ControllerBase
    {
        private readonly LojaRepositorio _repo;      

        public LojaController()
        {
            _repo = new LojaRepositorio();
        }
        
        [HttpGet("{id}")]
        public Loja Get(int id)
        {
            return _repo.SelecionePorId(id);
        }
        
        [HttpPost]
        public void Post([FromBody] LojaDTO dto)
        {
            var loja = new Loja();
            loja.Cadastrar( dto.idProduto, dto.quantidadeLocal, dto.quantidadeMinima);

            _repo.Incluir(loja);
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LojaDTO dto)
        {
            var loja = new Loja();
            loja.Alterar(id, dto.Categoria, dto.Subcategoria);

            _repo.Alterar(loja);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
