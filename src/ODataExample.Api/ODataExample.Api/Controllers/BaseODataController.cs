using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExample.Api.Swagger;
using ODataExample.Application.Interfaces;

using System.Runtime.Serialization;
using ODataExample.Application.Const;
using System.Net;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ODataExample.Api.Controllers
{
    public class BaseODataController<TModel, TKey> : ODataController where TModel : class
    {
        private readonly IGenericRepository<TModel, TKey> _repository;

        public BaseODataController(IGenericRepository<TModel, TKey> repository)
        {
            _repository = repository;
        }

        [EnableQuery(PageSize = Constants.PAGE_SIZE)]
        [ProducesResponseType(typeof(PageResult), (int)HttpStatusCode.OK)]
        public IQueryable<TModel> Get([SwaggerHide] ODataQueryOptions<TModel> options) 
            => _repository.Queryable();

        [EnableQuery]
        [ProducesResponseType(typeof(SingleResult), (int)HttpStatusCode.OK)]
        public SingleResult<TModel> Get([SwaggerHide] ODataQueryOptions<TModel> options, TKey key) 
            => SingleResult.Create(_repository.Queryable(key));

        [ProducesResponseType(typeof(CreatedODataResult<object>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] TModel entity)
            => Created(await _repository.Insert(entity));

        [ProducesResponseType(typeof(UpdatedODataResult<object>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Patch(TKey key, [FromBody] Delta<TModel> entity)
        {
            var currentEntity = await _repository.GetById(key);
            entity.Patch(currentEntity);
            return Updated(await _repository.Update(currentEntity));
        }

        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(TKey key)
        {
            var entity = await _repository.GetById(key);

            if(entity == null) return NotFound();

            await _repository.Delete(entity);
            return NoContent();
        }

    }   
}
