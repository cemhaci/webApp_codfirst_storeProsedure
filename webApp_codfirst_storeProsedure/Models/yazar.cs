using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webApp_codfirst_storeProsedure.Models
{
    [Table("yazar")]
    public class yazar
    {
        public int ID { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public DateTime dogumTarihi { get; set; }


    }
}