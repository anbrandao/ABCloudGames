namespace AndreBrandaoCloudGamesApi.ExceptionsBase
{
    public class ErrorOnValidationException : AndreBrandaoCloudGamesException
    {

        public ICollection<string> ErrorMessages { get; set; }
        public ErrorOnValidationException(ICollection<string> errors)
        {
            ErrorMessages = errors;
        }
    }
}
