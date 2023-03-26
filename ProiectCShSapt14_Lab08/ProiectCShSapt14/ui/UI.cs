using ProiectCShSapt14.model;
using ProiectCShSapt14.model.validator;
using ProiectCShSapt14.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.ui
{
    public class UI
    {
        private Service service;

        public UI(Service service)
        {
            this.service = service;
        }

        private void showMenu()
        {
            Console.WriteLine("1. Afisare jucatori pentru echipa data");
            Console.WriteLine("2. Afisare jucatori activi ai unei echipe de la un anumit meci dat");
            Console.WriteLine("3. Afisare meciuri dintr-o perioada calendaristica");
            Console.WriteLine("4. Afisare scor pentru un meci dat");
            Console.WriteLine("x. Iesire din aplicatie");
        }

        private void cerinta1()
        {
            Console.WriteLine("Dati numele echipei:");
            string numeEchipa = Console.ReadLine();

            List<Jucator> laEchipa = service.filterJucatoriLaEchipa(numeEchipa);
            
            Console.WriteLine($"Jucatorii de la echipa {numeEchipa} sunt: ");
            laEchipa.ForEach(e => Console.WriteLine(e));
        }

        private void cerinta2()
        {
            Console.WriteLine("Dati ID meci:");
            string idMeci = Console.ReadLine();

            Meci gasit = service.findMeci(idMeci);
            Console.WriteLine($"Ati selectat meciul {gasit}");

            Console.WriteLine("Dati numele echipei:");
            string numeEchipa = Console.ReadLine();
            if (!(numeEchipa.Equals(gasit.E1.Nume) || numeEchipa.Equals(gasit.E2.Nume)))
            {
                throw new ValidationException("Echipa data nu exista pentru meciul dat!");
            }


            List<JucatorActiv> final = service.filterJucatoriActivi_MeciEchipa(idMeci, numeEchipa);
            
            Console.WriteLine($"Jucatorii activi de la meciul {idMeci} si echipa {numeEchipa}:");
            final.ForEach(e => {
                String numeJ = service.findAllJucatori().Find(l => l.ID.Equals(e.IdJucator)).Nume;
                Console.WriteLine($"JucatorActiv: {e} Nume: {numeJ}");
            }); 
        }

        private void cerinta3()
        {
            Console.WriteLine("Dati data de inceput: dd/mm/yyyy");
            string data1 = Console.ReadLine();
            DateTime d1 = DateTime.ParseExact(data1, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine("Dati data de sfarsit: dd/mm/yyyy");
            string data2 = Console.ReadLine();
            DateTime d2 = DateTime.ParseExact(data2, "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            var rez = service.filterMeciPerioada(d1, d2);
            rez.ForEach(e => Console.WriteLine(e));
        }

        private void cerinta4()
        {
            service.findAllMeci().ForEach(e => Console.WriteLine(e));

            Console.WriteLine("Dati id meci:");
            string idMeci = Console.ReadLine();
            Meci m = service.findMeci(idMeci);

            Console.WriteLine($"Meci: {m}");

            string echipa1 = m.E1.Nume;
            string echipa2 = m.E2.Nume;

            //jucatorii activi de la meciul dat de la prima echipa => apoi:
            //calculam suma punctelor adunate de jucatori
            int scorE1 = service.filterJucatoriActivi_MeciEchipa(idMeci, echipa1)
                .Select(j => j.NrPuncteInscrise).ToList().Sum();
            
            Console.WriteLine($"{echipa1}: {scorE1} puncte");

            //jucatorii activi de la meciul dat de la a doua echipa => apoi:
            //calculam suma punctelor adunate de jucatori
            int scorE2 = service.filterJucatoriActivi_MeciEchipa(idMeci, echipa2)
                .Select(j => j.NrPuncteInscrise).ToList().Sum();

            Console.WriteLine($"{echipa2}: {scorE2} puncte");
            
            //tabela cu scorurile
            Console.WriteLine($"{echipa1}: {scorE1} - {echipa2}: {scorE2}");
        }
        public void run()
        {
            bool running = true;
            while (running)
            {
                showMenu();
                Console.WriteLine("Alegeti optiunea:");
                string opt=Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        try
                        {
                            cerinta1();
                        }catch(ValidationException e)
                        {
                            Console.WriteLine($"Eroare: {e.Message}");
                        }
                        break;
                    case "2":
                        try
                        {
                            cerinta2();
                        }catch(ValidationException e)
                        {
                            Console.WriteLine($"Eroare: {e.Message}");
                        }
                        break;
                    case "3":
                        try
                        {
                            cerinta3();
                        }catch(ValidationException e)
                        {
                            Console.WriteLine($"Eroare: {e.Message}");
                        }
                        break;
                    case "4": cerinta4();
                        break;
                    case "x":
                        Console.WriteLine("Bye!");
                        running = false;
                        break;
                    default: Console.WriteLine("Optiune invalida!");
                        break;
                }
            }
        }
    }
}