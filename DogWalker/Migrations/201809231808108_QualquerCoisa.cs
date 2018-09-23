namespace DogWalker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QualquerCoisa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Solicitacaos",
                c => new
                    {
                        SolicitacaoId = c.Int(nullable: false, identity: true),
                        Mensagem = c.String(),
                        Destinatario_UsuarioId = c.Int(),
                        Remetente_UsuarioId = c.Int(),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.SolicitacaoId)
                .ForeignKey("dbo.Usuarios", t => t.Destinatario_UsuarioId)
                .ForeignKey("dbo.Usuarios", t => t.Remetente_UsuarioId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId)
                .Index(t => t.Destinatario_UsuarioId)
                .Index(t => t.Remetente_UsuarioId)
                .Index(t => t.Usuario_UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Solicitacaos", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Solicitacaos", "Remetente_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Solicitacaos", "Destinatario_UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Solicitacaos", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Solicitacaos", new[] { "Remetente_UsuarioId" });
            DropIndex("dbo.Solicitacaos", new[] { "Destinatario_UsuarioId" });
            DropTable("dbo.Solicitacaos");
        }
    }
}
