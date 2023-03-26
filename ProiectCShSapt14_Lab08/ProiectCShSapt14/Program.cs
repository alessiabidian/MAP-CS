using ProiectCShSapt14.model;
using ProiectCShSapt14.model.validator;
using ProiectCShSapt14.repository;
using ProiectCShSapt14.service;
using ProiectCShSapt14.ui;
using System.Globalization;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace ProiectCShSapt14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Elevi:");
            ElevValidator valEl= new ElevValidator();
            IRepository<string, Elev> r0 = new ElevFileRepo(valEl,"C:\\Users\\aless\\OneDrive\\Documente\\2022 Year 2\\2022 MAP - C#\\ProiectCShSapt14_Lab08\\ProiectCShSapt14\\data\\elevi.txt");
            foreach (Elev e in r0.FindAll())
            {
                Console.WriteLine(e);
            }
                     
            Console.WriteLine("Echipe:");
            EchipaValidator valE = new EchipaValidator();
            IRepository<string, Echipa> r1 = new EchipaFileRepo(valE,"C:\\Users\\aless\\OneDrive\\Documente\\2022 Year 2\\2022 MAP - C#\\ProiectCShSapt14_Lab08\\ProiectCShSapt14\\data\\echipe.txt");
            foreach (Echipa e in r1.FindAll())
            {
                Console.WriteLine(e);
            }
            
            Console.WriteLine("Jucatori activi: ");
            JucatorActivValidator valJA= new JucatorActivValidator();
            IRepository<string, JucatorActiv> r2 = new JucatorActivFileRepo(valJA,"C:\\Users\\aless\\OneDrive\\Documente\\2022 Year 2\\2022 MAP - C#\\ProiectCShSapt14_Lab08\\ProiectCShSapt14\\data\\jucatoriactivi.txt");
            foreach (JucatorActiv j in r2.FindAll())
            {
                Console.WriteLine(j);
            }

            Console.WriteLine("Jucatori: ");
            JucatorValidator valJ= new JucatorValidator();
            string fJucatori = "C:\\Users\\aless\\OneDrive\\Documente\\2022 Year 2\\2022 MAP - C#\\ProiectCShSapt14_Lab08\\ProiectCShSapt14\\data\\jucatori.txt";
            IRepository<string, Jucator> r3 = new JucatorFileRepo(valJ,fJucatori);
            foreach (Jucator j in r3.FindAll())
            {
                Console.WriteLine(j);
            }
            
            Console.WriteLine("Meciuri:");
            MeciValidator valM= new MeciValidator();
            IRepository<string, Meci> r4 = new MeciFileRepo(valM,"C:\\Users\\aless\\OneDrive\\Documente\\2022 Year 2\\2022 MAP - C#\\ProiectCShSapt14_Lab08\\ProiectCShSapt14\\data\\meciuri.txt");
            foreach (Meci m in r4.FindAll())
            {
                Console.WriteLine(m);
            }

            Service service = new Service(r1, r2, r3, r4);
            
            UI ui = new UI(service);
            ui.run();
        }
    }
}