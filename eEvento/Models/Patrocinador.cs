using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eEvento.Models
{
    public class Patrocinador
    {
        [Key]
        [Column("id_patrocinador")]
        public int PatrocinadorId { get; set; }

        [DisplayName("Patrocinador")]
        [Column("nome_patrocinador")]
        [Required(ErrorMessage = "O nome do patrocinador é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Contato")]
        [Column("contato")]
        [Required(ErrorMessage = "O contato do patrocinador é obrigatório.")]
        [StringLength(200, ErrorMessage = "O contato deve ter no máximo 200 caracteres.")]
        public string Contato { get; set; }

        // Relacionamento 
        public virtual ICollection<Evento> Eventos { get; set; }
    }

}