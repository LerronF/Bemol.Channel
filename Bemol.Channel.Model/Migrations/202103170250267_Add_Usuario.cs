namespace Bemol.Channel.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Usuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "CPF", c => c.String());
            AddColumn("dbo.Usuarios", "Logradouro", c => c.String());
            AddColumn("dbo.Usuarios", "Bairro", c => c.String());
            AddColumn("dbo.Usuarios", "Cidade", c => c.String());
            AddColumn("dbo.Usuarios", "UF", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "UF");
            DropColumn("dbo.Usuarios", "Cidade");
            DropColumn("dbo.Usuarios", "Bairro");
            DropColumn("dbo.Usuarios", "Logradouro");
            DropColumn("dbo.Usuarios", "CPF");
        }
    }
}
