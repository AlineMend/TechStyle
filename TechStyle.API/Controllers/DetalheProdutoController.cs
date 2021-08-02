using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechStyle.API.DTO;
using TechStyle.Dados.Repositorio;
using TechStyle.Dominio.Modelo;

namespace TechStyle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalheProdutoController : ControllerBase
    {
        private readonly DetalheProdutoRepositorio _repo;      

        public DetalheProdutoController()
        {
            _repo = new DetalheProdutoRepositorio();
        }

        
        [HttpGet("{id}")]
        public DetalheProduto Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }
        
        [HttpPost]
        public void Post([FromBody] DetalheProdutoDTO dto)
        {
            var detalheProduto = new DetalheProduto();
            detalheProduto.Cadastrar(dto.produto, dto.material, dto.cor, dto.marca , dto.modelo , dto.tamanho);

            _repo.Incluir(detalheProduto);
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DetalheProdutoDTO dto)
        {
            var detalheProduto = new DetalheProduto();
            detalheProduto.Alterar(id, dto.Categoria, dto.Subcategoria);

            _repo.Alterar(detalheProduto);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           
        }
    }
}
