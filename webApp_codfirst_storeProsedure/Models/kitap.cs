using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webApp_codfirst_storeProsedure.Models
{
    [Table("kitap")]
    public class kitap
    {
        [Key]
        public int ID { get; set; }
        [Required,StringLength(50)]
        public string adi { get; set; }
        public string aciklama { get; set; }

        [Required,StringLength(50)]  //required zorunlu alan demek
        public string aciklama2 { get; set; }
        public DateTime yayintarihi { get; set; }

        public string aciklama4 { get; set; }

       public yazar yazars { get; set; }

    }
}