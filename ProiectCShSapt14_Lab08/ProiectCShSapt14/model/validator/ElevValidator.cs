namespace ProiectCShSapt14.model.validator
{
    public class ElevValidator : IValidator<Elev>
    {
        public void validate(Elev e)
        {
            string errors = "";
            if (e.Nume.Equals("")) errors += "Numele nu poate fi vid!\n";
            if (e.Scoala.Equals("")) errors += "Scoala nu poate fi vida!";
            if(errors.Length>0) throw new ValidationException(errors);
        }
    }
}