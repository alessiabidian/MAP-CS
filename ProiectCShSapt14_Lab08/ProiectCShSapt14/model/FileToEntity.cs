using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.model
{
    public class FileToEntity
    {
        public static Echipa CreateEchipa(string line)
        {
            string[] fields= line.Split(';');
            Echipa echipa = new Echipa()
            {
                ID = fields[0],
                Nume = fields[1]
            };
            return echipa;
        }
        
        public static Elev CreateElev(string linie)
        {
            string[] fields = linie.Split(";");
            Elev elev = new Elev()
            {
                ID = fields[0],
                Nume = fields[1],
                Scoala = fields[2]
            };
            return elev;
        }

        public static JucatorActiv CreateJucatorActiv(string linie)
        {
            string[] fields= linie.Split(";");
            JucatorActiv j = new JucatorActiv()
            {
                ID = fields[0] + fields[1],
                IdJucator = fields[0],
                IdMeci = fields[1],
                NrPuncteInscrise= int.Parse(fields[2]),
                TipJucator= (Tip)Enum.Parse(typeof(Tip), fields[3])
            };
            return j;
        }

    }
}