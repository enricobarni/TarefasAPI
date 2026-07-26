using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasAPI.Application.DTOs;
using TarefasAPI.Infrastructure.DB;
using TarefasAPI.Domain.Entites;
using TarefasAPI.Domain.Enums;

namespace TarefasAPI.Domain.Interfaces
{
    public interface ITarefaService
    {
        List<Tarefa> GetAll();

        List<Tarefa> BuscarPorTitulo(string titulo);

        List<Tarefa> BuscarPorData(DateTime data);

        List<Tarefa> BuscarPorStatus(StatusAtivo status);

        List<string> Validacao(TarefaCreateDTO tarefaCreateDTO);

        Tarefa? BuscarPorId(int id);

        Tarefa? Atualizar(int id, TarefaUpdateDTO tarefaUpdateDTO);
        
        void Create(TarefaCreateDTO tarefaCreateDTO);

        bool Deletar(int id);
    }
}
