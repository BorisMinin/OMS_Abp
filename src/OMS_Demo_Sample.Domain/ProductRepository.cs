using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS_Demo_Sample
{
    public class ProductRepository : : EfCoreRepository<MyDbContext, Person, Guid>, IPersonRepository
    {
    }
}