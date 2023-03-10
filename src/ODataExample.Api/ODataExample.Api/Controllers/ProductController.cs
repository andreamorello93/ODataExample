using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExample.Application.DTOs;
using ODataExample.Application.Interfaces;
using ODataExample.Application.Repositories;
using ODataExample.DAL.Data;
using ODataExample.DAL.Models;

namespace ODataExample.Api.Controllers
{
    public class ProductController : BaseODataDTOController<ProductDTO, Product, int>
    {
        public ProductController(IGenericRepository<Product, int> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}