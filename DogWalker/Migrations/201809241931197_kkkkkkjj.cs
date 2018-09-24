namespace DogWalker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkkkkkjj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Usuario_UsuarioId", c => c.Int());
            CreateIndex("dbo.Usuarios", "Usuario_UsuarioId");
            AddForeignKey("dbo.Usuarios", "Usuario_UsuarioId", "dbo.Usuarios", "UsuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "Usuario_UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Usuarios", new[] { "Usuario_UsuarioId" });
            DropColumn("dbo.Usuarios", "Usuario_UsuarioId");
        }
    }
}
