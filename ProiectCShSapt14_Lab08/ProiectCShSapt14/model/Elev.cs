using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.model
{

    public class Elev: Entity<string>
    {
        public string Nume { get; set; }
        public string Scoala { get; set; }

        public override string ToString()
        {
            return "ID: "+ID + "; Nume: " + Nume + "; Scoala: " + Scoala;
        }
    }

}