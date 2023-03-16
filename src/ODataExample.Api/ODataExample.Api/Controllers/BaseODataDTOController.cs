using System.Net;
using System.Threading;
using AutoMapper;
using AutoMapper.AspNet.OData;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using ODataExample.Api.Swagger;
using ODataExample.Application.Const;
using ODataExample.Application.DTOs;
using ODataExample.Application.Interfaces;
using ODataExample.Application.Processors;
using ODataExample.Application.Repositories;
using ODataExample.DAL.Models;

namespace ODataExample.Api.Controllers
{
    public class BaseODataDTOController<TDTO, TKey> : ODataController where TDTO : class
    {
        private readonly IODataDTOProcessor<TDTO, TKey> _oDataDtoProcessor;

        public BaseODataDTOController(IODataDTOProcessor<TDTO, TKey> oDataDtoProcessor)
        {
            _oDataDtoProcessor = oDataDtoProcessor;
        }

        [ProducesResponseType(typeof(PageResult), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<TDTO>> Get([SwaggerHide] ODataQueryOptions<TDTO> options)
            => await _oDataDtoProcessor.Get(options);

        [EnableQuery]
        [ProducesResponseType(typeof(SingleResult), (int)HttpStatusCode.OK)]
        public SingleResult<TDTO> Get([SwaggerHide] ODataQueryOptions<TDTO> options, TKey key)
            => _oDataDtoProcessor.Get(options, key);

        [ProducesResponseType(typeof(CreatedODataResult<object>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] TDTO entity)
            => Created(await _oDataDtoProcessor.Post(entity));

        [ProducesResponseType(typeof(UpdatedODataResult<object>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Patch(TKey key, [FromBody] Delta<TDTO> entity)
        {
            var result = await _oDataDtoProcessor.Patch(key, entity);

            if(result == HttpStatusCode.NotFound)
                return NotFound();
            
            return Updated(entity);
        }
        
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(TKey key)
        {
            var result = await _oDataDtoProcessor.Delete(key);

            if (result == HttpStatusCode.NotFound)
                return NotFound();

            return NoContent();
        }

    }
}
