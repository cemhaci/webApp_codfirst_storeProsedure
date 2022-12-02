using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using webApp_codfirst_storeProsedure.Migrations;

namespace webApp_codfirst_storeProsedure.Models
{
    public class databasecontest:DbContext
    { 

        public databasecontest()
        {
            //Database.SetInitializer(new veritabanıolusturucu());  //procedure leri oluşturmayı tetiklemek için
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<databasecontest,Configuration>());  //databasein en son versiyonu
        }
        //public void procedureinsertData()
        //{
        //    Database.ExecuteSqlCommand("Exec insertData");
        //}

        public List<kitapyayin> precedurekitapdata(int byil, int syil)
        {
            //Database.ExecuteSqlCommand("exec kitapgetir @p0,@p1",2010,2020);
             //tablo oluşturup listelemesi için bu metodu yazdıkve bu adım da geri döndüreceği tür bir tabolu vermeli o yüzden yeni bir class oluşturup tablo içersindeki datetime ve sayi bilgilerinı classa yazıp yeni bir tür oluşturup oraya yazdık
            return Database.SqlQuery<kitapyayin>("exec kitapgetir @p0,@p1",byil,syil).ToList();

        }
       public List<yazar> viewyazargetir()
        {
            return Database.SqlQuery<yazar>("select * from yazar").ToList();
        }
        public List<kitap> viewkitapgetir()
        {
            return Database.SqlQuery<kitap>("select * from kitap").ToList();
        }
        public virtual DbSet<kitap> kitaplar { get;set;}  //kitaplar tablomuzu temsil ediyor
        public  virtual DbSet<yazar> yazarlar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) //model create edilirken
        {
           modelBuilder.Entity<kitap>().MapToStoredProcedures(config=>{config.Insert(i=>i.HasName("kitapEkle"));config.Update(u=>u.HasName("kitapGuncelle"));config.Delete(d=>d.HasName("kitapSil"));});  //kitap için store procedure oluştur dedik.delete indert update procuder leri.config ile yaptığımız iprocedure lerin isimlerini yazmak için
            //hocanın notlarda parametrelerinde değişştirileceği gösterildi
        }
    }
    public class veritabanıolusturucu : CreateDatabaseIfNotExists<databasecontest>
    {
        protected override void Seed(databasecontest context) //database oluştururken yapacağı işlemler
        {
            context.Database.ExecuteSqlCommand( "create proc insertData as begin insert into kitap values('homo saphiens','deneme','test','2010-01-01') insert into kitap values('harry potter','büyü','test','2020-02-02') end");  //tırnak içine ne yazarsak exec edicektir
            context.Database.ExecuteSqlCommand("create proc kitapGetir @p0 int,@p1 int as begin select yayintarihi, COUNT(yayintarihi) as sayi from kitap where YEAR(yayintarihi) between @p0 and @p1 group by yayintarihi end");
            context.Database.ExecuteSqlCommand("create view kitapbilgi as select adi,yayintarihi from kitap");
        } 
    }
}