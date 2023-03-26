using ProiectCShSapt14.model;
using ProiectCShSapt14.model.validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.repository
{
    public class MeciFileRepo : AbstractFileRepo<string, Meci>
    {
        public MeciFileRepo(IValidator<Meci> vali, string filename) : base(vali, filename, null)//FileToEntity.CreateMeci)//
        {
            loadfromfile();
        }
        
        private new void loadfromfile()
        {
            string fname = "C:\\Users\\aless\\OneDrive\\Documente\\2022 Year 2\\2022 MAP - C#\\ProiectCShSapt14_Lab08\\ProiectCShSapt14\\data\\echipe.txt";
            List<Echipa> echipe = DataReader.ReadData(fname, FileToEntity.CreateEchipa);

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                int ct = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields= line.Split(';');
                    Echipa e1 = echipe.Find(e => e.ID.Equals(fields[0]));
                    Echipa e2 = echipe.Find(e => e.ID.Equals(fields[1]));
                    String id = ct.ToString();
                    Meci meci = new Meci()
                    {
                        ID = id,
                        E1 = e1,
                        E2 = e2,
                        Data = DateTime.ParseExact(fields[2], "d/M/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                    };
                    
                    base.Save(meci);
                    ct++;
                }
            }
        }
    }
}