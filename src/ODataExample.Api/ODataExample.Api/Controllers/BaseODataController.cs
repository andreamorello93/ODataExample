using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExample.Application.Interfaces;
using ODataExample.DAL.Models;

namespace ODataExample.Api.Controllers
{
    public class BaseODataController<TModel, TKey> : ODataController where TModel : class
    {
        private readonly IGenericRepository<TModel, TKey> _repository;

        public BaseODataController(IGenericRepository<TModel, TKey> repository)
        {
            _repository = repository;
        }

        [EnableQuery(PageSize = 500)]
        public IQueryable<TModel> Get() 
            => _repository.Queryable();

        [EnableQuery]
        public  SingleResult<TModel> Get(TKey key) 
            => SingleResult.Create(_repository.Queryable(key));
        
    }
}
