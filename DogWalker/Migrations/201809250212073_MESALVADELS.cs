namespace DogWalker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MESALVADELS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuarios", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Solicitacaos", "Usuario_UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Usuarios", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Solicitacaos", new[] { "Usuario_UsuarioId" });
            CreateTable(
                "dbo.Amizades",
                c => new
                    {
                        AmizadeId = c.Int(nullable: false, identity: true),
                        Usuario1Id = c.Int(nullable: false),
                        Usuario2Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AmizadeId);
            
            DropColumn("dbo.Usuarios", "Usuario_UsuarioId");
            DropColumn("dbo.Solicitacaos", "Usuario_UsuarioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Solicitacaos", "Usuario_UsuarioId", c => c.Int());
            AddColumn("dbo.Usuarios", "Usuario_UsuarioId", c => c.Int());
            DropTable("dbo.Amizades");
            CreateIndex("dbo.Solicitacaos", "Usuario_UsuarioId");
            CreateIndex("dbo.Usuarios", "Usuario_UsuarioId");
            AddForeignKey("dbo.Solicitacaos", "Usuario_UsuarioId", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Usuarios", "Usuario_UsuarioId", "dbo.Usuarios", "UsuarioId");
        }
    }
}
