namespace Bemol.Channel.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CEP_Telefone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "CEP", c => c.String());
            AddColumn("dbo.Usuarios", "Telefone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Telefone");
            DropColumn("dbo.Usuarios", "CEP");
        }
    }
}
