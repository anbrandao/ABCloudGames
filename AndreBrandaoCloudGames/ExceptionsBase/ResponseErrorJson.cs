namespace AndreBrandaoCloudGamesApi.ExceptionsBase
{
    public class ResponseErrorJson
    {

        public ICollection<string> ErrorMessages { get; private set; }
        public ResponseErrorJson(ICollection<string> errors)
        {
            ErrorMessages = errors;
        }
        public ResponseErrorJson(string error)
        {
            ErrorMessages = new List<string>();
            ErrorMessages.Add(error);
        }
    }
}
