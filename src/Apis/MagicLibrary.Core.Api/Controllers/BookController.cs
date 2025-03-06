using MagicLibrary.Core.Domain.Interfaces;
using MagicLibrary.Core.Domain.Models;
using MagicLibrary.Core.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicLibrary.Core.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]/[action]")]

    public class BookController : AGenericController<Book, BookEntity>
    {
        public BookController(IService<Book, BookEntity> service) : base(service)
        {
        }
    }
}
