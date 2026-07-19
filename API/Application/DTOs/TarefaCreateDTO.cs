using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TarefasAPI.Application.DTOs
{
    public record TarefaCreateDTO(string Titulo, string Descricao);
}
