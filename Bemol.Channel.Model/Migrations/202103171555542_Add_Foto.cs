namespace Bemol.Channel.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Foto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Foto", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Foto");
        }
    }
}
