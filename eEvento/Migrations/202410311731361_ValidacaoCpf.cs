namespace eEvento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacaoCpf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participante", "cpf", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Participante", "cpf", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
