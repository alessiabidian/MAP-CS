namespace ProiectCShSapt14.model.validator
{
    public class JucatorActivValidator : IValidator<JucatorActiv>
    {
        public void validate(JucatorActiv e)
        {
            string errors = "";
            if (e.TipJucator.ToString().Equals("")) errors += "Tipul nu poate fi null!";
            if(errors.Length>0) throw new ValidationException(errors);  
        }
    }
}