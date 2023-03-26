namespace ProiectCShSapt14.model.validator
{
    public class EchipaValidator: IValidator<Echipa>
    {
        public void validate(Echipa e)
        {
            bool valid = true;
            string errors = "";
            if(e.Nume.Equals(""))
            {
                valid=false;
                valid = false;
                errors += "Numele nu poate fi vid!";
            }
            if(errors.Length> 0) {
                throw new ValidationException(errors);
            }
        }
    }
}