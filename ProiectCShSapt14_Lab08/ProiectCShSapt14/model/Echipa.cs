using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.model
{
    public class Echipa: Entity<string>
    {
        public string Nume { get; set; }

        public override string ToString()
        {
            return "ID: "+this.ID.ToString() + "; Nume: " + Nume;
        }
    }
}