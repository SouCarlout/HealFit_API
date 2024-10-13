using AutoMapper;
using HealFit.DTO;
using HealFit.Migrations;
using HealFit.Models;
using HealFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealFit.Controllers;

[Route("[controller]")]
[ApiController]
public class ConsumoController : ControllerBase {

    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public ConsumoController(IUnitOfWork uof, IMapper mapper) {

        _uof = uof;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<ConsumoDTO>> Post(ConsumoDTO consumo) {

        if (consumo == null) {

            return BadRequest("Nao foi recebido nenhum consumo");
        }

        var consumoMap = _mapper.Map<Consumo>(consumo);

        var consumoCriado = _uof.ConsumoRepository.Create(consumoMap);
        await _uof.CommitAsync();

        var consumoCriadoDTO = _mapper.Map<ConsumoDTO>(consumoCriado);

        return Ok(consumoCriadoDTO);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ConsumoDTO>> Get(int id) {

        var consumo = await _uof.ConsumoRepository.GetAsync(u => u.ConsumoId == id);

        if (consumo == null) {

            return BadRequest("Consumo nao encontrado");
        }

        var dadosDTO = _mapper.Map<ConsumoDTO>(consumo);

        return Ok(dadosDTO);
    }

    [HttpGet("Usuario/{id:int}")]
    public async Task<ActionResult<IEnumerable<ConsumoDTO>>> GetConsumoByUserId(int id) {

        var consumo = await _uof.ConsumoRepository.GetAllAsync();

        var filtro = consumo.Where(u => u.UsuarioId == id);

        if (filtro == null) {

            return BadRequest("Consumo nao encontrado");
        }

        var dadosDTO = _mapper.Map<IEnumerable<ConsumoDTO>>(filtro);

        return Ok(dadosDTO);
    }

    [HttpPut]
    public async Task<ActionResult<ConsumoDTO>> Put(ConsumoDTO consumo) {

        if (consumo == null) {

            return BadRequest("Nao foi possivel atualizar o consumo");
        }

        var consumoAtual = await _uof.ConsumoRepository.GetAsync(d => d.ConsumoId == consumo.ConsumoId);

        if (consumoAtual == null) {

            return BadRequest("Nao foi possivel recuperar o consumo");
        }

        _mapper.Map(consumo, consumoAtual);

        _uof.ConsumoRepository.Update(consumoAtual);
        await _uof.CommitAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ConsumoDTO>> Delete(int id) {

        var consumo = await _uof.ConsumoRepository.GetAsync(c => c.ConsumoId == id);

        if (consumo == null) {

            return BadRequest("Consumo nao encontrado");
        }

        _uof.ConsumoRepository.Delete(consumo);
        await _uof.CommitAsync();

        return Ok();
    }
}
