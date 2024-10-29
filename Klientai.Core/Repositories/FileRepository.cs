using Klientai.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klientai.Core.Repositories
{
    public class FileRepository
    {
        private string _fileLocation;
        public FileRepository(string fileLocation)
        {
            _fileLocation = fileLocation;
        }

        public List<Klientas> GautiVisusKlientus()
        {
            List<Klientas> klientai = new List<Klientas>();
            using(StreamReader sr = new StreamReader(_fileLocation))
            {
                while(!sr.EndOfStream)
                {
                    string eilute = sr.ReadLine();
                    if(string.IsNullOrEmpty(eilute))
                    {
                        break;
                    }
                    string[] reiksmes = eilute.Split(';');
                    klientai.Add(new Klientas(long.Parse(reiksmes[0]), reiksmes[1], reiksmes[2], DateOnly.Parse(reiksmes[3])));
                }
            }

            return klientai;
        }
        public void RasytiKlientusIFaila(List<Klientas> klientai)
        {
            using(StreamWriter sw = new StreamWriter(_fileLocation))
            {
                foreach(Klientas k in klientai)
                {
                    sw.WriteLine($"{k.AsmensKodas};{k.Vardas};{k.Pavarde};{k.GimimoData}");
                }
                sw.Close();
            }
        }
    }
}
