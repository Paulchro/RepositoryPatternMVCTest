using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepositoryPatternMVC.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NorthwindEntities _context;
        public CustomerRepository()
        {
            _context = new NorthwindEntities();
        }
        public CustomerRepository(NorthwindEntities context)
        {
            _context = context;
        }
        public void Delete(int CustomerID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customers GetById(int CustomerID)
        {
            return _context.Customers.Find(CustomerID);
        }

        public void Insert(Customers customers)
        {
            _context.Customers.Add(customers);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Customers customers)
        {
            _context.Entry(customers).State = EntityState.Modified;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}