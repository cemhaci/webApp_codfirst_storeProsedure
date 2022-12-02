namespace webApp_codfirst_storeProsedure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KitapTableColumnaciklama4 : DbMigration
    {
        //add-migration diyip ekledik
        public override void Up()
        {
            AddColumn("dbo.kitap", "aciklama4", c => c.String(nullable:false,defaultValue:"test",defaultValueSql:"test2")); //parantez içine biz yazdık nullable null geçilemez diyor.
            AlterStoredProcedure(
                "dbo.kitapEkle",
                p => new
                    {
                        adi = p.String(maxLength: 50),
                        aciklama = p.String(),
                        aciklama2 = p.String(maxLength: 50),
                        yayintarihi = p.DateTime(),
                        aciklama4 = p.String(),
                    },
                body:
                    @"INSERT [dbo].[kitap]([adi], [aciklama], [aciklama2], [yayintarihi], [aciklama4])
                      VALUES (@adi, @aciklama, @aciklama2, @yayintarihi, @aciklama4)
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [dbo].[kitap]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [dbo].[kitap] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            AlterStoredProcedure(
                "dbo.kitapGuncelle",
                p => new
                    {
                        ID = p.Int(),
                        adi = p.String(maxLength: 50),
                        aciklama = p.String(),
                        aciklama2 = p.String(maxLength: 50),
                        yayintarihi = p.DateTime(),
                        aciklama4 = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[kitap]
                      SET [adi] = @adi, [aciklama] = @aciklama, [aciklama2] = @aciklama2, [yayintarihi] = @yayintarihi, [aciklama4] = @aciklama4
                      WHERE ([ID] = @ID)"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.kitap", "aciklama4");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
