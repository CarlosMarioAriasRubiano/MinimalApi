using MinimalApi.Domain.Context;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Domain.Services
{
    public class CustomerService
    {
        private readonly PersistenceContext context;

        public CustomerService(PersistenceContext context)
        {
            this.context = context;
        }

        public async Task UpdateCustomersBalanceByInvoices(List<Invoice> invoices)
        {
            var customerIds = invoices
                .Select(i => i.CustomerId)
                .Distinct()
                .ToList();

            var customers = context.Customer
                .Where(c => customerIds.Contains(c.Id))
                .ToList();

            foreach (var customer in customers)
            {
                var total = invoices
                    .Where(i => i.CustomerId.Equals(customer.Id))
                    .Sum(i => i.Total);

                customer.Balance -= total;
            }

            await context.SaveChangesAsync();
        }
    }
}
