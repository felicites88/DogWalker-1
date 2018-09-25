namespace DogWalker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LUL : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Passeios", "Cachorro_CachorroId", "dbo.Cachorroes");
            DropForeignKey("dbo.Passeios", "Passeador_UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Passeios", new[] { "Cachorro_CachorroId" });
            DropIndex("dbo.Passeios", new[] { "Passeador_UsuarioId" });
            AddColumn("dbo.Passeios", "PasseadorId", c => c.Int(nullable: false));
            AddColumn("dbo.Passeios", "ClienteId", c => c.Int(nullable: false));
            AddColumn("dbo.Passeios", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Passeios", "Cachorro_CachorroId");
            DropColumn("dbo.Passeios", "Passeador_UsuarioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Passeios", "Passeador_UsuarioId", c => c.Int());
            AddColumn("dbo.Passeios", "Cachorro_CachorroId", c => c.Int());
            DropColumn("dbo.Passeios", "Status");
            DropColumn("dbo.Passeios", "ClienteId");
            DropColumn("dbo.Passeios", "PasseadorId");
            CreateIndex("dbo.Passeios", "Passeador_UsuarioId");
            CreateIndex("dbo.Passeios", "Cachorro_CachorroId");
            AddForeignKey("dbo.Passeios", "Passeador_UsuarioId", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Passeios", "Cachorro_CachorroId", "dbo.Cachorroes", "CachorroId");
        }
    }
}
