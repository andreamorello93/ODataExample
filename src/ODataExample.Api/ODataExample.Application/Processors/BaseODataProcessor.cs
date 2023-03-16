using AutoMapper.AspNet.OData;
using AutoMapper;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using ODataExample.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ODataExample.Application.Processors
{
    public interface IODataProcessor<TModel, TKey> where TModel : class
    {
        IQueryable<TModel> Get();
        SingleResult<TModel> Get(TKey key);
        Task<TModel> Post(TModel entity);
        Task<HttpStatusCode> Patch(TKey key, Delta<TModel> entity);
        Task<HttpStatusCode> Delete(TKey key);
    }

    public class BaseODataProcessor<TModel, TKey> : IODataProcessor<TModel, TKey> where TModel : class 
    {
        private readonly IGenericRepository<TModel, TKey> _repository;

        public BaseODataProcessor(IGenericRepository<TModel, TKey> repository)
        {
            _repository = repository;
        }
        public IQueryable<TModel> Get() => _repository.Queryable();

        public SingleResult<TModel> Get(TKey key) => SingleResult.Create(_repository.Queryable(key));

        public async Task<TModel> Post([FromBody] TModel entity)
            => await _repository.Insert(entity);

        public async Task<HttpStatusCode> Patch(TKey key, [FromBody] Delta<TModel> entity)
        {
            var currentEntity = await _repository.GetById(key);

            entity.Patch(currentEntity);

            await _repository.SaveChangesAsync();

            return HttpStatusCode.OK;
        }
        
        public async Task<HttpStatusCode> Delete(TKey key)
        {
            var entity = await _repository.GetById(key);

            if (entity == null) return HttpStatusCode.NotFound;

            await _repository.Delete(entity);

            return HttpStatusCode.NoContent;
        }

    }
}
