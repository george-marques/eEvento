namespace eEvento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventosOrganizador : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Evento", "Organizador_OrganizadorId", "dbo.Organizador");
            DropIndex("dbo.Evento", new[] { "Organizador_OrganizadorId" });
            RenameColumn(table: "dbo.Evento", name: "Organizador_OrganizadorId", newName: "id_organizador");
            AlterColumn("dbo.Evento", "id_organizador", c => c.Int(nullable: false));
            CreateIndex("dbo.Evento", "id_organizador");
            AddForeignKey("dbo.Evento", "id_organizador", "dbo.Organizador", "id_organizador", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "id_organizador", "dbo.Organizador");
            DropIndex("dbo.Evento", new[] { "id_organizador" });
            AlterColumn("dbo.Evento", "id_organizador", c => c.Int());
            RenameColumn(table: "dbo.Evento", name: "id_organizador", newName: "Organizador_OrganizadorId");
            CreateIndex("dbo.Evento", "Organizador_OrganizadorId");
            AddForeignKey("dbo.Evento", "Organizador_OrganizadorId", "dbo.Organizador", "id_organizador");
        }
    }
}
