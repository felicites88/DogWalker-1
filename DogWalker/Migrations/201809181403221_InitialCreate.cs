namespace DogWalker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cachorroes",
                c => new
                    {
                        CachorroId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Raca = c.String(),
                        Porte = c.String(),
                        Nascimento = c.DateTime(nullable: false),
                        ImagemUri = c.String(),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.CachorroId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId)
                .Index(t => t.Usuario_UsuarioId);
            
            CreateTable(
                "dbo.Passeios",
                c => new
                    {
                        PasseioId = c.Int(nullable: false, identity: true),
                        Preco = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Cachorro_CachorroId = c.Int(),
                        Passeador_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.PasseioId)
                .ForeignKey("dbo.Cachorroes", t => t.Cachorro_CachorroId)
                .ForeignKey("dbo.Usuarios", t => t.Passeador_UsuarioId)
                .Index(t => t.Cachorro_CachorroId)
                .Index(t => t.Passeador_UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Nascimento = c.DateTime(nullable: false),
                        Biografia = c.String(),
                        Logradouro = c.String(nullable: false),
                        Numero = c.Int(nullable: false),
                        Bairro = c.String(nullable: false),
                        Cidade = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        PrecoPasseio = c.Double(nullable: false),
                        ImagemUri = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passeios", "Passeador_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Cachorroes", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Passeios", "Cachorro_CachorroId", "dbo.Cachorroes");
            DropIndex("dbo.Passeios", new[] { "Passeador_UsuarioId" });
            DropIndex("dbo.Passeios", new[] { "Cachorro_CachorroId" });
            DropIndex("dbo.Cachorroes", new[] { "Usuario_UsuarioId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Passeios");
            DropTable("dbo.Cachorroes");
        }
    }
}
