using AutoMapper;
using HealFit.DTO;
using HealFit.Models;
using HealFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealFit.Controllers;

[Route("[controller]")]
[ApiController]
public class DadosController : ControllerBase {

    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public DadosController(IUnitOfWork uof, IMapper mapper) {

        _uof = uof;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<DadosDTO>>Post(DadosDTO dados) {

        if (dados == null) {

            return BadRequest("Nao foi recebido nenhum dado");
        }

        var dado = _mapper.Map<DadosPessoais>(dados);

        var dadoCriado = _uof.DadosRepository.Create(dado);
        await _uof.CommitAsync();

        var dadoCriadoDTO = _mapper.Map<DadosDTO>(dadoCriado);

        return Ok(dadoCriadoDTO);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DadosDTO>> Get(int id) {

        var dados = await _uof.DadosRepository.GetAsync(u => u.DadosId == id);

        if (dados == null) {

            return BadRequest("Usuario nao encontrado");
        }

        var dadosDTO = _mapper.Map<DadosDTO>(dados);

        return Ok(dadosDTO);
    }

    [HttpPut]
    public async Task<ActionResult<DadosDTO>> Put(DadosDTO dados) {

        if (dados == null) {

            return BadRequest("Nao foi possivel atualizar os dados");
        }

        var dadosAtual = await _uof.DadosRepository.GetAsync(d => d.DadosId == dados.DadosId);

        if (dadosAtual == null) {

            return BadRequest("Nao foi possivel recuperar o usuario");
        }

        _mapper.Map(dados, dadosAtual);

        //dadosAtual.DadosId = dados.DadosId;
        //dadosAtual.Nome = dados.Nome;
        //dadosAtual.Sobrenome = dados.Sobrenome;
        //dadosAtual.DataNascimento = dados.DataNascimento;
        //dadosAtual.Altura = dados.Altura;
        //dadosAtual.Peso = dados.Peso;
        //dadosAtual.Cep = dados.Cep;
        //dadosAtual.Cidade = dados.Cidade;
        //dadosAtual.Estado = dados.Estado;
        //dadosAtual.Bairro = dados.Bairro;
        //dadosAtual.Rua = dados.Rua;
        //dadosAtual.Numero = dados.Numero;
        //dadosAtual.Complemento = dados.Complemento;
        //dadosAtual.UsuarioId = dados.UsuarioId;

        _uof.DadosRepository.Update(dadosAtual);
        await _uof.CommitAsync();

        return Ok(dadosAtual);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<DadosDTO>> Delete(int id) {

        var dados = await _uof.DadosRepository.GetAsync(c => c.DadosId == id);

        if (dados == null) {

            return BadRequest("Usuario nao encontrado");
        }

        _uof.DadosRepository.Delete(dados);
        await _uof.CommitAsync();

        return Ok();
    }
}
