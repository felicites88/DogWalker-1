namespace DogWalker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class socorr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Solicitacaos", "Destinatario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Solicitacaos", "Remetente_UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Solicitacaos", new[] { "Destinatario_UsuarioId" });
            DropIndex("dbo.Solicitacaos", new[] { "Remetente_UsuarioId" });
            AddColumn("dbo.Solicitacaos", "RemetenteId", c => c.Int(nullable: false));
            AddColumn("dbo.Solicitacaos", "DestinatarioId", c => c.Int(nullable: false));
            DropColumn("dbo.Solicitacaos", "Mensagem");
            DropColumn("dbo.Solicitacaos", "Destinatario_UsuarioId");
            DropColumn("dbo.Solicitacaos", "Remetente_UsuarioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Solicitacaos", "Remetente_UsuarioId", c => c.Int());
            AddColumn("dbo.Solicitacaos", "Destinatario_UsuarioId", c => c.Int());
            AddColumn("dbo.Solicitacaos", "Mensagem", c => c.String());
            DropColumn("dbo.Solicitacaos", "DestinatarioId");
            DropColumn("dbo.Solicitacaos", "RemetenteId");
            CreateIndex("dbo.Solicitacaos", "Remetente_UsuarioId");
            CreateIndex("dbo.Solicitacaos", "Destinatario_UsuarioId");
            AddForeignKey("dbo.Solicitacaos", "Remetente_UsuarioId", "dbo.Usuarios", "UsuarioId");
            AddForeignKey("dbo.Solicitacaos", "Destinatario_UsuarioId", "dbo.Usuarios", "UsuarioId");
        }
    }
}
