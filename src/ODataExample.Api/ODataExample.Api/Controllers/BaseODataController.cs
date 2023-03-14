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
        
    }   
}
