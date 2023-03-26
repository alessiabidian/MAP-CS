namespace ProiectCShSapt14.model.validator
{
    public class JucatorValidator : IValidator<Jucator>
    {
        public void validate(Jucator e)
        {
            string errors = "";
            if (e.Nume.Equals("")) errors += "Numele nu poate fi vid!\n";
            if (e.Scoala.Equals("")) errors += "Scoala nu poate fi vida!\n";
            if(errors.Length>0) throw new ValidationException(errors);  
        }
    }
}