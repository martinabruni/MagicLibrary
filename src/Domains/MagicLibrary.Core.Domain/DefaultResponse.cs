namespace MagicLibrary.Core.Domain
{
    public class DefaultResponse<T>
    {
        public ApplicationStatusCode StatusCode { get; set; } = ApplicationStatusCode.NoContent;
        public T? Data { get; set; }
    }
}
