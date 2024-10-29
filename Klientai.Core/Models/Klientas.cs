using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klientai.Core.Models
{
    public class Klientas
    {
        public long AsmensKodas { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public DateOnly GimimoData { get; set; }

        public Klientas(long ak, string vardas, string pavarde, DateOnly gimimoData)
        {
            AsmensKodas = ak;
            Vardas = vardas;
            Pavarde = pavarde;
            GimimoData = gimimoData;
        }
        public Klientas()
        {

        }
    }
}
