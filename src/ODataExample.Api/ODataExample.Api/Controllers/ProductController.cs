using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataExample.Application.DTOs;
using ODataExample.Application.Interfaces;
using ODataExample.Application.Processors;
using ODataExample.Application.Repositories;
using ODataExample.DAL.Data;
using ODataExample.DAL.Models;

namespace ODataExample.Api.Controllers
{
    public class ProductController : BaseODataDTOController<ProductDTO, int>
    {
        public ProductController(IODataDTOProcessor<ProductDTO, int> oDataDtoProcessor) : base(oDataDtoProcessor)
        {

        }
    }
}