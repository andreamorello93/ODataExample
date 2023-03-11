using AutoMapper;
using AutoMapper.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExample.Api.Swagger;
using ODataExample.Application.DTOs;
using ODataExample.Application.Interfaces;
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

        [EnableQuery]
        public async Task<IEnumerable<TDTO>> Get([SwaggerHide] ODataQueryOptions<TDTO> options)
            => await _repository.Queryable().GetQueryAsync(_mapper, options);

        [EnableQuery]
        public async Task<SingleResult<TDTO>> Get([SwaggerHide] ODataQueryOptions<TDTO> options, TKey key)
            => SingleResult.Create(await _repository.Queryable(key).GetQueryAsync(_mapper, options));

    }
}
