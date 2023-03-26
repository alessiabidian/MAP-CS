using ProiectCShSapt14.model;
using ProiectCShSapt14.model.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.repository
{
    public class JucatorFileRepo : AbstractFileRepo<string, Jucator>
    {
        public JucatorFileRepo(IValidator<Jucator> vali, string filename) : base(vali, filename, null)//FileToEntity.CreateJucator)
        {
            loadfromfile();
        }

        private new void loadfromfile()
        {
            string fEchipe = "C:\\Users\\aless\\OneDrive\\Documente\\2022 Year 2\\2022 MAP - C#\\ProiectCShSapt14_Lab08\\ProiectCShSapt14\\data\\echipe.txt";
            List<Echipa> echipe = DataReader.ReadData(fEchipe, FileToEntity.CreateEchipa);

            string fElevi = "C:\\Users\\aless\\OneDrive\\Documente\\2022 Year 2\\2022 MAP - C#\\ProiectCShSapt14_Lab08\\ProiectCShSapt14\\data\\elevi.txt";
            List<Elev> elevi = DataReader.ReadData(fElevi, FileToEntity.CreateElev);
            

            string fJucator = "C:\\Users\\aless\\OneDrive\\Documente\\2022 Year 2\\2022 MAP - C#\\ProiectCShSapt14_Lab08\\ProiectCShSapt14\\data\\jucatori.txt";
            using (StreamReader sr= new StreamReader(fJucator))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields= line.Split(";");
                    Echipa ech = echipe.Find(e => e.ID.Equals(fields[0]));
                    Elev el = elevi.Find(el => el.ID.Equals(fields[1]));

      
                    Jucator j = new Jucator(ech)
                    {
                        ID = el.ID,
                        Nume = el.Nume,
                        Scoala = el.Scoala,
                    };
                    base.Save(j);
                }
            }
        }
    }
}