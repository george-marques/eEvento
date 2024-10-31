using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eEvento.Models
{
    public class Organizador
    {
        [Key]
        [Column("id_organizador")]
        public int OrganizadorId { get; set; }

        [DisplayName("Organizador")]
        [Column("nome_organizador")]
        [Required(ErrorMessage = "O nome do organizador é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Contato")]
        [Column("contato")]
        [Required(ErrorMessage = "O contato é obrigatório.")]
        [RegularExpression(@"^\(\d{2}\)\d{5}-\d{4}$", ErrorMessage = "O Contato deve estar no formato (99)99999-9999.")]
        public string Contato { get; set; }

        // Relacionamento
        public virtual ICollection<Evento> Eventos { get; set; }
    }

}