using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODataExample.DAL.Data;
using ODataExample.DAL.Models;

namespace ODataExample.Application.Repositories
{
    public class ProductRepository : GenericRepository<Product, int>
    {
        public ProductRepository(AdventureWorks2019Context context) : base(context)
        {
        }
    }
}
