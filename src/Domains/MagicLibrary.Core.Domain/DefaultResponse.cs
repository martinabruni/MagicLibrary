namespace MagicLibrary.Core.Domain
{
    public class DefaultResponse<T>
    {
        public ApplicationStatusCode applicationStatusCode { get; set; } = ApplicationStatusCode.NoContent;
        public T? Data { get; set; }
    }
}
