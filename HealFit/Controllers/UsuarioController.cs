using AutoMapper;
using HealFit.DTO;
using HealFit.DTO.Request;
using HealFit.DTO.Rsp;
using HealFit.Models;
using HealFit.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealFit.Controllers;

[Route("[controller]")]
[ApiController]
public class UsuarioController : ControllerBase {

    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public UsuarioController(IUnitOfWork uof, IMapper mapper) {

        _uof = uof;
        _mapper = mapper;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<LoginDTORequest>> Login([FromBody] LoginDTORequest modelo) {

        if (modelo == null) {
            return BadRequest("Nao foi recebido as informações de login");
        }

        var users = await _uof.UsuarioRepository.GetAllAsync();

        var user = users.FirstOrDefault(u => u.Email == modelo.Email && u.Senha == modelo.Senha);

        if (user == null) {
            return Unauthorized("Usuário ou senha inválidos");
        }

        return Ok(new LoginDTOResponse {
            UsuarioId = user.UsuarioId,
        });
    }

    [HttpPost("Registro")] // Registra o usuario
    public async Task<ActionResult<LoginDTORequest>> Post(LoginDTORequest model) {

        if (model is null) {
            return BadRequest("Erro ao cadastrar usuario");
        }

        var usuarios = await _uof.UsuarioRepository.GetAsync(u => u.Email == model.Email);

        if (usuarios is null) {

            var user = _mapper.Map<Usuario>(model);

            var userCriado = _uof.UsuarioRepository.Create(user);
            await _uof.CommitAsync();

            var userCriadoDTO = _mapper.Map<LoginDTO>(userCriado);

            return Ok(userCriadoDTO);

        }
        else {

            return BadRequest("Email ja cadastrado");
        }

    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LoginDTO>>Get (int id) {

        var usuarios = await _uof.UsuarioRepository.GetAsync(u => u.UsuarioId == id);

        if (usuarios == null) {

            return BadRequest("Usuario nao encontrado");
        }

        var usuarioDTO = _mapper.Map<LoginDTO>(usuarios);

        return Ok(usuarioDTO);

    }

    [HttpPut("RedefirSenha")]
    public async Task<ActionResult<LoginDTO>> Put(LoginDTO usuario) {

        var usuarios = await _uof.UsuarioRepository.GetAsync(u => u.UsuarioId == usuario.UsuarioId);

        if (usuarios == null) {

            return BadRequest("Nao foi possivel recuperar o usuario");
        }

        usuarios.Senha = usuario.Senha;

        _uof.UsuarioRepository.Update(usuarios);
        await _uof.CommitAsync();

        return Ok(usuarios);

    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<LoginDTO>> Delete(int id) {

        var user = await _uof.UsuarioRepository.GetAsync(c => c.UsuarioId == id);

        if (user == null) {
            return BadRequest("Usuario nao encontrado");
        }

        _uof.UsuarioRepository.Delete(user);
        await _uof.CommitAsync();

        return Ok();
    }
}
