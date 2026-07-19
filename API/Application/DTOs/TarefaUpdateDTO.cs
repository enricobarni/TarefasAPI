using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TarefasAPI.Domain.Enums;

namespace TarefasAPI.Application.DTOs
{
    public record TarefaUpdateDTO(string Titulo, string Descricao, StatusAtivo Status);
}
