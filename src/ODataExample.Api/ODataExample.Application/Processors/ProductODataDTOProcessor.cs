using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ODataExample.Application.DTOs;
using ODataExample.Application.Interfaces;
using ODataExample.DAL.Models;

namespace ODataExample.Application.Processors
{
    public class ProductODataDTOProcessor : BaseODataDTOProcessor<Product, ProductDTO, int>
    {
        public ProductODataDTOProcessor(IGenericRepository<Product, int> repository, IMapper mapper) : base(repository, mapper)
        {
                
        }
    }
}
