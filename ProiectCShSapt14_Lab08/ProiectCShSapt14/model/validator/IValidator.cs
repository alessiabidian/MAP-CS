namespace ProiectCShSapt14.model.validator
{
    public interface IValidator<E>
    {
        void validate(E e);
    }

}