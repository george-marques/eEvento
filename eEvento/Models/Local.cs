using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eEvento.Models
{
    public class Local
    {
        [Key]
        [Column("id_local")]
        public int LocalId { get; set; }

        [DisplayName("Local")]
        [Column("nome_local")]
        [Required(ErrorMessage = "O nome do local é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Endereço")]
        [Column("endereco")]
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres.")]
        public string Endereco { get; set; }

        [DisplayName("Capacidade Máxima")]
        [Column("capacidade_max")]
        [Range(1, 10000, ErrorMessage = "A capacidade máxima deve ser entre 1 e 10.000 pessoas.")]
        public int CapacidadeMaxima { get; set; }

        // Relacionamento
        public virtual ICollection<Evento> Eventos { get; set; }
    }

}