using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TarefasAPI.Application.DTOs;
using TarefasAPI.Application.Interfaces;
using TarefasAPI.Application.Services;
using TarefasAPI.Domain.Enums;
using TarefasAPI.Infrastructure.DB;

namespace TarefasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaServico;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaServico = tarefaService;
        }

        [HttpPost("tarefas")]
        public IActionResult CriarTafefa(
            [FromBody] TarefaCreateDTO tarefaCreateDTO,
            ITarefaService tarefaService
        )
        {
            var erros = tarefaService.Validacao(tarefaCreateDTO);

            if (erros.Count > 0)
            {
                return BadRequest();
            }

            tarefaService.Create(tarefaCreateDTO);

            return Ok();
        }

        [HttpGet("tarefas")]
        public IActionResult GetAll(ITarefaService tarefaService)
        {
            var tarefas = tarefaService.GetAll();
            return Ok(tarefas);
        }

        [HttpGet("tarefas/{id}")]
        public IActionResult GetPorId(int id, ITarefaService tarefaService)
        {
            var getId = tarefaService.BuscarPorId(id);

            if (getId is null)
            {
                return NotFound();
            }

            return Ok(getId);
        }

        [HttpGet("tarefas/titulo/{titulo}")]
        public IActionResult GetPorTitulo(string titulo, ITarefaService tarefaService)
        {
            var getTitulo = tarefaService.BuscarPorTitulo(titulo);
            return Ok(getTitulo);
        }

        [HttpGet("tarefas/data/{data}")]
        public IActionResult GetPorData(DateTime data, ITarefaService tarefaService)
        {
            var getData = tarefaService.BuscarPorData(data);
            return Ok(getData);
        }

        [HttpGet("tarefas/status/{status}")]
        public IActionResult GetPorStatus(StatusAtivo status, ITarefaService tarefaService)
        {
            var getStatus = tarefaService.BuscarPorStatus(status);
            return Ok(getStatus);
        }

        [HttpPut("tarefas/{id}")]
        public IActionResult Update(int id, TarefaUpdateDTO tarefaUpdateDTO, ITarefaService tarefaService)
        {
            var updateTarefa = tarefaService.Atualizar(id, tarefaUpdateDTO);

            if (updateTarefa is null)
            {
                return NotFound();
            }

            return Ok(updateTarefa);
        }

        [HttpDelete("tarefas/{id}")]
        public IActionResult Delete(int id, ITarefaService tarefaService)
        {
            var deleteTarefa = tarefaService.Deletar(id);

            if (deleteTarefa != true)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
