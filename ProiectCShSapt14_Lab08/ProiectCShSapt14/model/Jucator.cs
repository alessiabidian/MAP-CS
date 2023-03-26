using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCShSapt14.model
{
    public class Jucator : Elev
    {
        private Echipa echipa;
        public Jucator(Echipa e)
        {
            this.echipa = e;
        }

        public Echipa GetEchipa()
        {
            return this.echipa;
        }

        public override string ToString()
        {
            //return "ID echipa: " + echipaElev.ID + " Nume echipa: " + echipaElev.Nume + " ID Jucator: " + ID + " Nume Jucator: " + Nume + " Nume Scoala: " + Scoala;
            return $"ID Echipa: {echipa.ID} ; Nume Echipa: {echipa.Nume} | ID Jucator: {ID}; Nume Jucator: {Nume}| Scoala: {Scoala}";
        }
    }
}