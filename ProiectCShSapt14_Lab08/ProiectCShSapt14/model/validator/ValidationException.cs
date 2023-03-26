namespace ProiectCShSapt14.model.validator
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(String errMsg) : base(errMsg)
        {
        }
    }
}