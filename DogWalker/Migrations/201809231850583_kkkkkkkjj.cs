namespace DogWalker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkkkkkkjj : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cachorroes", "Usuario_UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Cachorroes", new[] { "Usuario_UsuarioId" });
            AddColumn("dbo.Cachorroes", "UsuarioId", c => c.Int(nullable: false));
            DropColumn("dbo.Cachorroes", "Usuario_UsuarioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cachorroes", "Usuario_UsuarioId", c => c.Int());
            DropColumn("dbo.Cachorroes", "UsuarioId");
            CreateIndex("dbo.Cachorroes", "Usuario_UsuarioId");
            AddForeignKey("dbo.Cachorroes", "Usuario_UsuarioId", "dbo.Usuarios", "UsuarioId");
        }
    }
}
