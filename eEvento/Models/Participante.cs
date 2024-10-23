using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace eEvento.Models
{
    public class Participante
    {
        [Key]
        [Column("id_participante")]
        public int ParticipanteId { get; set; }

        [DisplayName("Participante")]
        [Column("nome_participante")]
        [Required(ErrorMessage = "O nome do participante é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Email")]
        [Column("email")]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [DisplayName("CPF")]
        [Column("cpf")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        public string CPF { get; set; }

        // Relacionamento
        public virtual ICollection<Inscricao> Inscricoes { get; set; }

    }

}