using MagicLibrary.Core.Domain;
using MagicLibrary.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace MagicLibrary.Core.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]/[action]")]

    public abstract class AGenericController<TDomain, TEntity> : ControllerBase where TDomain : IEntity where TEntity : IEntity
    {
        protected readonly IService<TDomain, TEntity> _service;

        public AGenericController(IService<TDomain, TEntity> service)
        {
            _service = service;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TDomain model)
        {
            var result = await _service.AddAsync(model);
            var data = JsonSerializer.Serialize(result.Data);
            return result.StatusCode switch
            {
                ApplicationStatusCode.Created => CreatedAtAction(nameof(Get), new { id = result.Data!.Id }, data),
                ApplicationStatusCode.BadRequest => BadRequest(data),
                _ => StatusCode((int)result.StatusCode)
            };
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            var data = JsonSerializer.Serialize(result.Data);
            return result.StatusCode switch
            {
                ApplicationStatusCode.Success => Ok(data),
                ApplicationStatusCode.NoContent => NoContent(),
                ApplicationStatusCode.BadRequest => BadRequest(data),
                _ => StatusCode((int)result.StatusCode),
            };
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();

            if(result.Data.IsNullOrEmpty()) return NoContent();
            
            result.Data!.ToList().ForEach(m => JsonSerializer.Serialize(m));

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            var data = JsonSerializer.Serialize(result.Data);
            return result.StatusCode switch
            {
                ApplicationStatusCode.Success => Ok(data),
                ApplicationStatusCode.NoContent => NoContent(),
                ApplicationStatusCode.BadRequest => BadRequest(data),
                _ => StatusCode((int)result.StatusCode)
            };
        }
    }
}
