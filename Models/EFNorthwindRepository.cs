﻿using System.Linq;

namespace Northwind.Models
{
    public class EFNorthwindRepository : INorthwindRepository
    {
        // the repository class depends on the NorthwindContext service
        // which was registered at application startup
        private readonly NorthwindContext _context;
        public EFNorthwindRepository(NorthwindContext ctx)
        {
            _context = ctx;
        }
        // create IQueryable for Categories & Products
        public IQueryable<Category> Categories => _context.Categories;
        public IQueryable<Product> Products => _context.Products;
        public IQueryable<Discount> Discounts => _context.Discounts;
        public IQueryable<Contact> Contacts => _context.Contact;
        public IQueryable<Customer> Customers => _context.Customers;

        public IQueryable<Contact> Contact => throw new System.NotImplementedException();

        public void AddContact(Contact contact)
        {
            _context.Contact.Add(contact);
            _context.SaveChanges();
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            var customerToUpdate = _context.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            customerToUpdate.Address = customer.Address;
            customerToUpdate.City = customer.City;
            customerToUpdate.Region = customer.Region;
            customerToUpdate.PostalCode = customer.PostalCode;
            customerToUpdate.Country = customer.Country;
            customerToUpdate.Phone = customer.Phone;
            customerToUpdate.Fax = customer.Fax;
            _context.SaveChanges();
        }
    }
}