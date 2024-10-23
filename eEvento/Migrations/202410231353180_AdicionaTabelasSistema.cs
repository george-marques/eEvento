namespace eEvento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaTabelasSistema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        id_evento = c.Int(nullable: false, identity: true),
                        nome_evento = c.String(nullable: false, maxLength: 100),
                        descricao = c.String(nullable: false, maxLength: 500),
                        data_evento = c.DateTime(nullable: false),
                        id_local = c.Int(nullable: false),
                        capacidade = c.Int(nullable: false),
                        Organizador_OrganizadorId = c.Int(),
                    })
                .PrimaryKey(t => t.id_evento)
                .ForeignKey("dbo.Local", t => t.id_local, cascadeDelete: true)
                .ForeignKey("dbo.Organizador", t => t.Organizador_OrganizadorId)
                .Index(t => t.id_local)
                .Index(t => t.Organizador_OrganizadorId);
            
            CreateTable(
                "dbo.Inscricao",
                c => new
                    {
                        id_inscricao = c.Int(nullable: false, identity: true),
                        data_inscrição = c.DateTime(nullable: false),
                        id_evento = c.Int(nullable: false),
                        id_participante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_inscricao)
                .ForeignKey("dbo.Evento", t => t.id_evento, cascadeDelete: true)
                .ForeignKey("dbo.Participante", t => t.id_participante, cascadeDelete: true)
                .Index(t => t.id_evento)
                .Index(t => t.id_participante);
            
            CreateTable(
                "dbo.Participante",
                c => new
                    {
                        id_participante = c.Int(nullable: false, identity: true),
                        nome_participante = c.String(nullable: false, maxLength: 100),
                        email = c.String(nullable: false),
                        cpf = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.id_participante);
            
            CreateTable(
                "dbo.Local",
                c => new
                    {
                        id_local = c.Int(nullable: false, identity: true),
                        nome_local = c.String(nullable: false, maxLength: 100),
                        endereco = c.String(nullable: false, maxLength: 200),
                        capacidade_max = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_local);
            
            CreateTable(
                "dbo.Patrocinador",
                c => new
                    {
                        id_patrocinador = c.Int(nullable: false, identity: true),
                        nome_patrocinador = c.String(nullable: false, maxLength: 100),
                        contato = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.id_patrocinador);
            
            CreateTable(
                "dbo.Organizador",
                c => new
                    {
                        id_organizador = c.Int(nullable: false, identity: true),
                        nome_organizador = c.String(nullable: false, maxLength: 100),
                        contato = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.id_organizador);
            
            CreateTable(
                "dbo.EventoPatrocinador",
                c => new
                    {
                        EventoId = c.Int(nullable: false),
                        PatrocinadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventoId, t.PatrocinadorId })
                .ForeignKey("dbo.Evento", t => t.EventoId, cascadeDelete: true)
                .ForeignKey("dbo.Patrocinador", t => t.PatrocinadorId, cascadeDelete: true)
                .Index(t => t.EventoId)
                .Index(t => t.PatrocinadorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "Organizador_OrganizadorId", "dbo.Organizador");
            DropForeignKey("dbo.EventoPatrocinador", "PatrocinadorId", "dbo.Patrocinador");
            DropForeignKey("dbo.EventoPatrocinador", "EventoId", "dbo.Evento");
            DropForeignKey("dbo.Evento", "id_local", "dbo.Local");
            DropForeignKey("dbo.Inscricao", "id_participante", "dbo.Participante");
            DropForeignKey("dbo.Inscricao", "id_evento", "dbo.Evento");
            DropIndex("dbo.EventoPatrocinador", new[] { "PatrocinadorId" });
            DropIndex("dbo.EventoPatrocinador", new[] { "EventoId" });
            DropIndex("dbo.Inscricao", new[] { "id_participante" });
            DropIndex("dbo.Inscricao", new[] { "id_evento" });
            DropIndex("dbo.Evento", new[] { "Organizador_OrganizadorId" });
            DropIndex("dbo.Evento", new[] { "id_local" });
            DropTable("dbo.EventoPatrocinador");
            DropTable("dbo.Organizador");
            DropTable("dbo.Patrocinador");
            DropTable("dbo.Local");
            DropTable("dbo.Participante");
            DropTable("dbo.Inscricao");
            DropTable("dbo.Evento");
        }
    }
}
