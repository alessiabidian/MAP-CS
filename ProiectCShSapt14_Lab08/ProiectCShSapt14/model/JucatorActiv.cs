using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.model
{

    public enum Tip { Rezerva, Participant}
    
    public class JucatorActiv: Entity<string>
    {
        public string IdJucator {get; set;}
        public string IdMeci { get; set; }

        public int NrPuncteInscrise { get; set; }

        public Tip TipJucator { get; set; }

        public override string ToString()
        {
            return "ID: "+ ID+"| ID Jucator: " + IdJucator + "| ID Meci: " + IdMeci + "| Puncte: " + NrPuncteInscrise + "| Tip: " + TipJucator;
        }

    }
}