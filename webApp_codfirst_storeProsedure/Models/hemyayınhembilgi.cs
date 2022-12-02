using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApp_codfirst_storeProsedure.Models
{
    public class hemyayınhembilgi
    {
        public List<kitapyayin> kitapyayin { get; set; }
        public List<kitapbilgi> kitapbilgi { get; set; }
        public List<kitap> kitaps { get; set; }

        public List<yazar> yazars{ get; set; }

    
    }
}