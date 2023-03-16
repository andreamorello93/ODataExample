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
using ODataExample.Application.Processors;

namespace ODataExample.Api.Controllers
{
    public class BaseODataController<TModel, TKey> : ODataController where TModel : class
    {
        private readonly IODataProcessor<TModel, TKey> _oDataProcessor;

        public BaseODataController(IODataProcessor<TModel, TKey> oDataProcessor)
        {
            _oDataProcessor = oDataProcessor;
        }

        [EnableQuery(PageSize = Constants.PAGE_SIZE)]
        [ProducesResponseType(typeof(PageResult), (int)HttpStatusCode.OK)]
        public IQueryable<TModel> Get([SwaggerHide] ODataQueryOptions<TModel> options) => _oDataProcessor.Get();

        [EnableQuery]
        [ProducesResponseType(typeof(SingleResult), (int)HttpStatusCode.OK)]
        public SingleResult<TModel> Get([SwaggerHide] ODataQueryOptions<TModel> options, TKey key) => _oDataProcessor.Get(key);

        [ProducesResponseType(typeof(CreatedODataResult<object>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] TModel entity) => Created(await _oDataProcessor.Post(entity));

        [ProducesResponseType(typeof(UpdatedODataResult<object>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Patch(TKey key, [FromBody] Delta<TModel> entity)
        {
            var result = await _oDataProcessor.Patch(key, entity);

            if (result == HttpStatusCode.NotFound)
                return NotFound();

            return Updated(entity);
        }

        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(TKey key)
        {
            var result = await _oDataProcessor.Delete(key);

            if (result == HttpStatusCode.NotFound)
                return NotFound();

            return NoContent();
        }

    }   
}
