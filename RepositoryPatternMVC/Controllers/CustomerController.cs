using RepositoryPatternMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryPatternMVC.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        public CustomerController()
        {
            _customerRepository = new CustomerRepository(new NorthwindEntities());
        }

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _customerRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddCustomers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomers(Customers model)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Insert(model);
                _customerRepository.Save();
                return RedirectToAction("Index", "Customers");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditCustomers(int CustomersId)
        {
            Customers model = _customerRepository.GetById(CustomersId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCustomers(Customers model)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Update(model);
                _customerRepository.Save();
                return RedirectToAction("Index", "Customers");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteCustomers(int CustomersId)
        {
            Customers model = _customerRepository.GetById(CustomersId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int CustomersID)
        {
            _customerRepository.Delete(CustomersID);
            _customerRepository.Save();
            return RedirectToAction("Index", "Customers");
        }
    }
}