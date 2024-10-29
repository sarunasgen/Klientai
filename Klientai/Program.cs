using Klientai.Core.Models;
using Klientai.Core.Repositories;
using System;
using System.ComponentModel.Design;

namespace Klientai
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileRepository fileRepository = new FileRepository("Klientai.csv");

            List<Klientas> visiKlientai = fileRepository.GautiVisusKlientus();

            foreach (Klientas k in visiKlientai)
            {
                Console.WriteLine($"{k.Vardas} {k.Pavarde} {k.AsmensKodas} {k.GimimoData}");
            }

            Console.WriteLine("Iveskite asmens koda:");
            long ak = long.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite varda:");
            string vardas = Console.ReadLine();
            Console.WriteLine("Iveskite pavarde:");
            string pavarde = Console.ReadLine();
            Console.WriteLine("Iveskite gimimo data:");
            DateOnly gimimoData = DateOnly.Parse(Console.ReadLine());

            visiKlientai.Add(new Klientas(ak, vardas, pavarde, gimimoData));

            fileRepository.RasytiKlientusIFaila(visiKlientai);

            foreach(Klientas k in visiKlientai)
            {
                Console.WriteLine($"{k.Vardas} {k.Pavarde} {k.AsmensKodas} {k.GimimoData}");
            }
        }
    }
}