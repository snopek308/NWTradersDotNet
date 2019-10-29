
using System.Linq;

namespace Northwind.Models
{
    public interface INorthwindRepository
    {
        IQueryable<Category> Categories { get; }
        IQueryable<Product> Products { get; }
        IQueryable<Discount> Discounts { get; }
        IQueryable<Contact> Contact { get; }
        IQueryable<Customer> Customers { get; }


        //
        void AddContact(Contact contact);
        void AddCustomer(Customer customers);
        void EditCustomer(Customer customer);
    }
}