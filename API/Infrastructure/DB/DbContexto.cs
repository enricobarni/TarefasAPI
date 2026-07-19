using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TarefasAPI.Domain.Entites;

namespace TarefasAPI.Infrastructure.DB
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options)
            : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
