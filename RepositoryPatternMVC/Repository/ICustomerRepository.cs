using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternMVC.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetAll();
        Customers GetById(int CustomerID);
        void Insert(Customers customers);
        void Update(Customers customers);
        void Delete(int CustomerID);
        void Save();
    }
}
