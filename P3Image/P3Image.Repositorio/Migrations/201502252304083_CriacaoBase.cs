namespace P3Image.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ordem = c.Int(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 500),
                        Tipo = c.String(nullable: false),
                        Argumento = c.String(),
                        SubCategoria_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCategoria", t => t.SubCategoria_Id)
                .Index(t => t.SubCategoria_Id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 500),
                        Slug = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.SubCategoria",
                c => new
                    {
                        SubCategoriaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 500),
                        Slug = c.String(nullable: false, maxLength: 30),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoriaId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategoria", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Campos", "SubCategoria_Id", "dbo.SubCategoria");
            DropIndex("dbo.SubCategoria", new[] { "CategoriaId" });
            DropIndex("dbo.Campos", new[] { "SubCategoria_Id" });
            DropTable("dbo.SubCategoria");
            DropTable("dbo.Categoria");
            DropTable("dbo.Campos");
        }
    }
}
