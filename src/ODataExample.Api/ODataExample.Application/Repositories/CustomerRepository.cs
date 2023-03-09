using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODataExample.DAL.Data;
using ODataExample.DAL.Models;

namespace ODataExample.Application.Repositories
{
    public class CustomerRepository : GenericRepository<Customer, int>
    {
        public CustomerRepository(AdventureWorks2019Context context) : base(context)
        {
        }
    }
}
