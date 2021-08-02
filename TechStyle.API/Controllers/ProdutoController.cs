using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechStyle.API.DTO;
using TechStyle.Dados.Repositorio;
using TechStyle.Dominio.Modelo;

namespace TechStyle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoRepositorio _repo;      

        public ProdutoController()
        {
            _repo = new ProdutoRepositorio();
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return _repo.SelecionarTudo();
        }
        
        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            return _repo.SelecionarPorId(id);
        }
        
        [HttpPost]
        public void Post([FromBody] ProdutoDTO dto)
        {
            var produto = new Produto();
            produto.Cadastrar(dto.valorVenda, dto.nome, dto.sku, segmento.Id);

            _repo.Incluir(produto);
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProdutoDTO dto)
        {
            var produto = new Produto();
            produto.Alterar(id, dto.Categoria, dto.Subcategoria);

            _repo.Alterar(produto);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
