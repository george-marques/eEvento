namespace eEvento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacaoContatos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizador", "contato", c => c.String(nullable: false));
            AlterColumn("dbo.Patrocinador", "contato", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patrocinador", "contato", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Organizador", "contato", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
