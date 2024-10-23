using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace eEvento.Models
{
    public class Inscricao
    {
        [Key]
        [Column("id_inscricao")]
        public int InscricaoId { get; set; }

        [DisplayName("Data de Inscrição")]
        [Column("data_inscrição")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A data de inscrição é obrigatória.")]
        public DateTime DataInscricao { get; set; }

        // Chaves estrangeiras
        [DisplayName("Evento")]
        [Column("id_evento")]
        [Required(ErrorMessage = "O evento é obrigatório.")]
        public int EventoId { get; set; }
        public virtual Evento Evento { get; set; }

        [DisplayName("Participante")]
        [Column("id_participante")]
        [Required(ErrorMessage = "O participante é obrigatório.")]
        public int ParticipanteId { get; set; }
        public virtual Participante Participante { get; set; }

        // Validações
        public bool ValidarDataInscricao()
        {
            return DataInscricao <= Evento.Data;
        }
    }

}