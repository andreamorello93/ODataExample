using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using AutoMapper.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using ODataExample.Application.Const;
using ODataExample.Application.Interfaces;

namespace ODataExample.Application.Processors
{
    public interface IODataDTOProcessor<TDTO, TKey> where TDTO : class
    {
        Task<IEnumerable<TDTO>> Get(ODataQueryOptions<TDTO> options);
        SingleResult<TDTO> Get(ODataQueryOptions<TDTO> options, TKey key);
        Task<TDTO> Post(TDTO entity);
        Task<HttpStatusCode> Patch(TKey key, Delta<TDTO> entity);
        Task<HttpStatusCode> Delete(TKey key);
    }

    public class BaseODataDTOProcessor<TModel, TDTO, TKey> : IODataDTOProcessor<TDTO, TKey> where TModel : class where  TDTO : class
    {
        private readonly IGenericRepository<TModel, TKey> _repository;
        private readonly IMapper _mapper;

        public BaseODataDTOProcessor(IGenericRepository<TModel, TKey> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDTO>> Get(ODataQueryOptions<TDTO> options)
            => (await _repository.Queryable().GetQueryAsync(_mapper, options,
                new QuerySettings() { ODataSettings = new ODataSettings() { PageSize = Constants.PAGE_SIZE } }));

        public SingleResult<TDTO> Get(ODataQueryOptions<TDTO> options, TKey key)
            => SingleResult.Create(_repository.Queryable(key).GetQuery(_mapper, options));

        public async Task<TDTO> Post(TDTO entity)
            => _mapper.Map<TDTO>(await _repository.Insert(_mapper.Map<TModel>(entity)));

        public async Task<HttpStatusCode> Patch(TKey key, Delta<TDTO> entity)
        {
            var currentEntity = await _repository.GetById(key);

            if (currentEntity == null) return HttpStatusCode.NotFound;

            var dto = _mapper.Map<TDTO>(currentEntity);

            entity.Patch(dto);

            _mapper.Map(dto, currentEntity);

            await _repository.SaveChangesAsync();

            return HttpStatusCode.OK;
        }

        public async Task<HttpStatusCode> Delete(TKey key)
        {
            var currentEntity = await _repository.GetById(key);

            if (currentEntity == null) return HttpStatusCode.NotFound;

            await _repository.Delete(currentEntity);

            return HttpStatusCode.NoContent;
        }
    }
}
