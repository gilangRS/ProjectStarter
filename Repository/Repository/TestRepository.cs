using DBContext;
using DBContext.Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TestRepository : ITestRepository
    {
        TestingContext context = new TestingContext();

        public TestRepository()
        {
            context.Person.AsNoTracking();
        }

        public IEnumerable<Person> GetData()
        {
            return context.Person.ToList();
        }
        
    }
}
