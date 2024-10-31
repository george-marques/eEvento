using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;

namespace eEvento.Models
{
    public class Evento
    {
        [Key]
        [Column("id_evento")]
        public int EventoId { get; set; }

        [DisplayName("Evento")]
        [Column("nome_evento")]
        [Required(ErrorMessage = "O nome do evento é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do evento deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Column("descricao")]
        [Required(ErrorMessage = "A descrição do evento é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string Descricao { get; set; }

        [DisplayName("Data do Evento")]
        [Column("data_evento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A data do evento é obrigatória.")]
        public DateTime Data { get; set; }

        [DisplayName("Local")]
        [Column("id_local")]
        [Required(ErrorMessage = "O local do evento é obrigatório.")]
        public int LocalId { get; set; }

        public virtual Local Local { get; set; }

        [DisplayName("Capacidade")]
        [Column("capacidade")]
        [Range(1, 10000, ErrorMessage = "A capacidade deve ser entre 1 e 10.000 pessoas.")]
        [Required(ErrorMessage = "A capacidade é obrigatório.")]
        public int Capacidade { get; set; }

        [DisplayName("Organizador")]
        [Column("id_organizador")]
        [Required(ErrorMessage = "O organizador do evento é obrigatório.")]
        public int OrganizadorId { get; set; }  // Essa é a chave estrangeira

        // Relacionamentos
        public virtual Organizador Organizador { get; set; }
        public virtual ICollection<Inscricao> Inscricoes { get; set; }
        public virtual ICollection<Patrocinador> Patrocinadores { get; set; }

        // Lista de patrocinadores selecionados
        public List<int> PatrocinadorIds { get; set; }

        // Lista de patrocinadores disponíveis para seleção
        public List<Patrocinador> PatrocinadoresDisponiveis { get; set; } = new List<Patrocinador>();


        // Validações
        public bool ValidarCapacidade()
        {
            return Inscricoes?.Count <= Capacidade;
        }

        public bool ValidarData()
        {
            return Data > DateTime.Now;
        }
    }

}