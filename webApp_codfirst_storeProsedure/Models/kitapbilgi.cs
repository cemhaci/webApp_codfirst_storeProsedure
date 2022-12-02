using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApp_codfirst_storeProsedure.Models
{
    public class kitapbilgi
    {
        public string adi { get; set; }
        public DateTime yayintarihi { get; set; }
        public kitap Kitaps {get;set;}
    }
}