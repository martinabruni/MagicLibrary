namespace MagicLibrary.Core.Domain
{
    public enum ApplicationStatusCode
    {
        Success = 200,
        Created = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500
    }
}