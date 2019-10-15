using System.Linq;

namespace Northwind.Models
{
    public class EFNorthwindRepository : INorthwindRepository
    {
        // the repository class depends on the NorthwindContext service
        // which was registered at application startup
        private NorthwindContext context;
        public EFNorthwindRepository(NorthwindContext ctx)
        {
            context = ctx;
        }
        // create IQueryable for Categories & Products
        public IQueryable<Category> Categories => context.Categories;
        public IQueryable<Product> Products => context.Products;
        public IQueryable<Discount> Discounts => context.Discounts;
        public IQueryable<Contact> Contact => context.Contact;
        public IQueryable<Customer> Customers => context.Customers;

        //adding the form to the database
        public void AddContact(Contact contact)
        {
            context.Contact.Add(contact);
            context.SaveChanges();
        }

        public void AddCustomer(Customer customers)
        {
            //the array and then the .Add adds objects to the arrayList
            context.Customers.Add(customers);
            //saves what you push to your database
            context.SaveChanges();
        }
    }
}