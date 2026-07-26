using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using TarefasAPI.Application.DTOs;
using TarefasAPI.Domain.Interfaces;
using TarefasAPI.Domain.Entites;
using TarefasAPI.Domain.Enums;
using TarefasAPI.Infrastructure.DB;


namespace TarefasAPI.Domain.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly DbContexto _context;

        public TarefaService(DbContexto context)
        {
            _context = context;
        }

        public List<Tarefa> GetAll()
        {
            return _context.Tarefas.ToList();
        }

        public List<Tarefa> BuscarPorData(DateTime data)
        {
            var inicio = data.Date;
            var fim = inicio.AddDays(1);
            return _context.Tarefas.Where(x => x.DataCriacao >= inicio && x.DataCriacao < fim).ToList();
        }

        public Tarefa? BuscarPorId(int id)
        {
            return _context.Tarefas.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Tarefa> BuscarPorStatus(StatusAtivo status)
        {
            return _context.Tarefas.Where(x => x.Status == status).ToList();
        }

        public List<Tarefa> BuscarPorTitulo(string titulo)
        {
            return _context.Tarefas.Where(x => x.Titulo.Contains(titulo)).ToList();
        }

        public void Create(TarefaCreateDTO tarefaCreateDTO)
        {
            var tarefa = new Tarefa
            {
                Titulo = tarefaCreateDTO.Titulo,
                Descricao = tarefaCreateDTO.Descricao,
                DataCriacao = DateTime.UtcNow,
                Status = StatusAtivo.Pendente,
            };

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public Tarefa? Atualizar(int id, TarefaUpdateDTO tarefaUpdateDTO)
        {
            var tarefa = BuscarPorId(id);

            if (tarefa is null)
            {
                return null;
            }

            tarefa.Id = tarefa.Id;
            tarefa.Titulo = tarefaUpdateDTO.Titulo;
            tarefa.Descricao = tarefaUpdateDTO.Descricao;
            tarefa.DataCriacao = tarefa.DataCriacao;
            tarefa.Status = tarefaUpdateDTO.Status;

            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();

            return tarefa;
        }

        public bool Deletar(int id)
        {
            var delete = BuscarPorId(id);

            if (delete is null)
            {
                return false;
            }

            _context.Tarefas.Remove(delete);
            _context.SaveChanges();

            return true;
        }

        public List<string> Validacao(TarefaCreateDTO tarefaCreateDTO)
        {
            List<string> listaErros = new List<string>();

            var tituloExiste = _context.Tarefas.Any(x => x.Titulo == tarefaCreateDTO.Titulo);

            if (tituloExiste)
            {
                listaErros.Add("Já existe uma tarefa com esse Título!");
            }
            if (string.IsNullOrEmpty(tarefaCreateDTO.Titulo))
            {
                listaErros.Add("O título não pode estar vazio");
            }
            if (string.IsNullOrEmpty(tarefaCreateDTO.Descricao))
            {
                listaErros.Add("A Descrição não pode estar vazia");
            }

            return listaErros;
        }
    }
}
