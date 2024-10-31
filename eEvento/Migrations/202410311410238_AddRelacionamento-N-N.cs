namespace eEvento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelacionamentoNN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patrocinador", "Evento_EventoId", c => c.Int());
            CreateIndex("dbo.Patrocinador", "Evento_EventoId");
            AddForeignKey("dbo.Patrocinador", "Evento_EventoId", "dbo.Evento", "id_evento");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patrocinador", "Evento_EventoId", "dbo.Evento");
            DropIndex("dbo.Patrocinador", new[] { "Evento_EventoId" });
            DropColumn("dbo.Patrocinador", "Evento_EventoId");
        }
    }
}
