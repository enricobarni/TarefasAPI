using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TarefasAPI.Domain.Enums;

namespace TarefasAPI.Domain.Entites
{
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; } = default!;

        [Required]
        [StringLength(150)]
        public string Descricao { get; set; } = default!;

        public DateTime DataCriacao { get; set; }

        [Required]
        public StatusAtivo Status { get; set; }
    }
}
