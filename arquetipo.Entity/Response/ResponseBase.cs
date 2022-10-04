namespace arquetipo.Entity.Response
{
    public abstract class ResponseBase
    {
        public StatusCodes codigo = Ok;
        public bool Success { get; set; } = true;
        public string Message { get; set; } = Constants.Constants.ResponseConstants.Success;
    }
}
