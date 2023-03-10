using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExample.Application.Interfaces;
using ODataExample.Application.Repositories;
using ODataExample.DAL.Data;
using ODataExample.DAL.Models;

namespace ODataExample.Api.Controllers
{
    public class CustomerController : BaseODataController<Customer, int>
    {
        public CustomerController(IGenericRepository<Customer, int> repository) : base(repository)
        {

        }
    }
}