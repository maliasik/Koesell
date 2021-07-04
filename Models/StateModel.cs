using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koesell.Models
{
    public class StateModel
    {
        public int UrunSayisi { get; set; }
        public int SiparisSayisi { get; set; }
        public int BekleyenSiparis { get; set; }
        public int TamamlananSiparis { get; set; }
        public int PaketlenenSiparis { get; set; }
        public int KargolananSiparis { get; set; }
    }
}