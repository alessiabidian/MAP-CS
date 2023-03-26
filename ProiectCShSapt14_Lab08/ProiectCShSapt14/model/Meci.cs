using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.model
{

    public class Meci: Entity<string>
    {
        public Echipa E1 { get; set; }
        public Echipa E2 { get; set; }
        public DateTime Data { get; set; }

        public override string ToString()
        {
            return "ID Meci: "+ ID+"| Echipa 1: " + E1 + "| Echipa 2: " + E2 + "| Data: " + Data.ToString("d/M/yyyy", CultureInfo.InvariantCulture);
        }
    }

}