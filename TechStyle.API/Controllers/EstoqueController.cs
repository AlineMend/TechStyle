using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechStyle.API.DTO;
using TechStyle.Dados.Repositorio;
using TechStyle.Dominio.Modelo;

namespace TechStyle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueRepositorio _repo;      

        public EstoqueController()
        {
            _repo = new EstoqueRepositorio();
        }

        [HttpGet]
        public IEnumerable<Estoque> Get()
        {
            return _repo.SelecionarTudo();
        }
        
        [HttpGet("{id}")]
        public Estoque Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }
        
        [HttpPost]
        public void Post([FromBody] EstoqueDTO dto)
        {
            var estoque = new Estoque();
            estoque.Cadastrar(dto.Categoria, dto.Subcategoria);

            _repo.Incluir(estoque);
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EstoqueDTO dto)
        {
            var estoque = new Estoque();
            estoque.Alterar(id, dto.Categoria, dto.Subcategoria);

            _repo.Alterar(estoque);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
