using System.Globalization;

namespace ProiectCShSapt14.model.validator
{
    public class MeciValidator : IValidator<Meci>
    {
        public void validate(Meci e)
        {
            string errors = "";
            if (e.E1.Nume.Equals("")) errors += "Scoala nu poate fi vida!\n";
            if (e.E2.Nume.Equals("")) errors += "Scoala nu poate fi vida!\n";
            if (e.Data.ToString("d/M/yyyy", CultureInfo.InvariantCulture).Equals(""))
                errors += "Data invalida!";
            if(errors.Length>0) throw new ValidationException(errors);  
        }
    }
}