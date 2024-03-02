using EncurtadorDeUrlLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncurtadorDeUrlLibrary.Models
{
    public class EncurtadorDeUrl : EncurtadorDeUrlService
    {
        public int RequisicaoID { get; set; }
        public string UrlOriginal { get; set; }
        public string UrlCurta { get; set; }
        public int TempoDeValidade { get; set; }
    }
}
