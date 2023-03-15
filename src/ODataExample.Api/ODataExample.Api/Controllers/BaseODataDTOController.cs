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
using Microsoft.Extensions.Options;
using ODataExample.Api.Swagger;
using ODataExample.Application.Const;
using ODataExample.Application.DTOs;
using ODataExample.Application.Interfaces;
using ODataExample.Application.Repositories;
using ODataExample.DAL.Models;

namespace ODataExample.Api.Controllers
{
    public class BaseODataDTOController<TDTO, TModel, TKey> : ODataController where TModel : class where TDTO : class
    {
        private readonly IGenericRepository<TModel, TKey> _repository;
        private readonly IMapper _mapper;

        public BaseODataDTOController(IGenericRepository<TModel, TKey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(PageResult), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<TDTO>> Get([SwaggerHide] ODataQueryOptions<TDTO> options)
            => (await _repository.Queryable().GetQueryAsync(_mapper, options, 
                new QuerySettings(){ ODataSettings = new ODataSettings(){ PageSize = Constants.PAGE_SIZE } }));

        [EnableQuery]
        [ProducesResponseType(typeof(SingleResult), (int)HttpStatusCode.OK)]
        public SingleResult<TDTO> Get([SwaggerHide] ODataQueryOptions<TDTO> options, TKey key)
            => SingleResult.Create(_repository.Queryable(key).GetQuery(_mapper, options));

        [ProducesResponseType(typeof(CreatedODataResult<object>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] TDTO entity)
            => Created(_mapper.Map<TDTO>(await _repository.Insert(_mapper.Map<TModel>(entity))));

        [ProducesResponseType(typeof(UpdatedODataResult<object>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Patch(TKey key, [FromBody] Delta<TDTO> entity)
        {
            var currentEntity = await _repository.GetById(key);
            var dto = _mapper.Map<TDTO>(currentEntity);
            entity.Patch(dto);
            _mapper.Map(dto, currentEntity);
            await _repository.Update(currentEntity);
            return Updated(dto);
        }

        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(TKey key)
        {
            var entity = await _repository.GetById(key);

            if (entity == null) return NotFound();

            await _repository.Delete(entity);
            return NoContent();
        }

    }
}
