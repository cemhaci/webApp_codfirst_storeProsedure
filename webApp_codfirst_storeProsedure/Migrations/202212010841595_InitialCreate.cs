namespace webApp_codfirst_storeProsedure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.kitap",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        adi = c.String(nullable: false, maxLength: 50),
                        aciklama = c.String(),
                        yayintarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateStoredProcedure(
                "dbo.kitapEkle",
                p => new
                    {
                        adi = p.String(maxLength: 50),
                        aciklama = p.String(),
                        yayintarihi = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[kitap]([adi], [aciklama], [yayintarihi])
                      VALUES (@adi, @aciklama, @yayintarihi)
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [dbo].[kitap]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [dbo].[kitap] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            CreateStoredProcedure(
                "dbo.kitapGuncelle",
                p => new
                    {
                        ID = p.Int(),
                        adi = p.String(maxLength: 50),
                        aciklama = p.String(),
                        yayintarihi = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[kitap]
                      SET [adi] = @adi, [aciklama] = @aciklama, [yayintarihi] = @yayintarihi
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "dbo.kitapSil",
                p => new
                    {
                        ID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[kitap]
                      WHERE ([ID] = @ID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.kitapSil");
            DropStoredProcedure("dbo.kitapGuncelle");
            DropStoredProcedure("dbo.kitapEkle");
            DropTable("dbo.kitap");
        }
    }
}
