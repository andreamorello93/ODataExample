using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExample.Application.Interfaces;
using ODataExample.Application.Repositories;
using ODataExample.DAL.Data;
using ODataExample.DAL.Models;

namespace ODataExample.Api.Controllers
{
    public class CustomersController : ODataController
    {
        private readonly IGenericRepository<Customer, int> _repository;

        public CustomersController(IGenericRepository<Customer, int> repository)
        {
            _repository = repository;
        }

        [EnableQuery]
        public IQueryable<Customer> Get()
            => _repository.Queryable();
        
    }
}