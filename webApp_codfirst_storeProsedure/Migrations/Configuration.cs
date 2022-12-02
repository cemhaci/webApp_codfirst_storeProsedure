namespace webApp_codfirst_storeProsedure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<webApp_codfirst_storeProsedure.Models.databasecontest>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "webApp_codfirst_storeProsedure.Models.databasecontest";
            AutomaticMigrationDataLossAllowed=true;
        }

        protected override void Seed(webApp_codfirst_storeProsedure.Models.databasecontest context)
        {
            for(int i=0; i < 10; i++)
            {
                context.kitaplar.AddOrUpdate(new Models.kitap()  //her çalıştırıldığıda eklememesi için addorupdate diyoruz
                {
                    ID=i+1,
                    adi=FakeData.NameData.GetCompanyName(),
                    aciklama=FakeData.TextData.GetSentence(),
                    yayintarihi= FakeData.DateTimeData.GetDatetime(),
                    aciklama2="test",
                    aciklama4="test2"
                    
            });
                context.SaveChanges();


                //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method
                //  to avoid creating duplicate seed data.
            }
            for(int j=0; j < 10; j++)
                {
                    context.yazarlar.AddOrUpdate(new Models.yazar(){
                        ID=j + 1, 
                        isim= FakeData.NameData.GetFirstName(),
                        soyisim=FakeData.NameData.GetSurname(),
                        dogumTarihi=FakeData.DateTimeData.GetDatetime()

                    });
                        
                }
                context.SaveChanges();
        }
    }
}          

