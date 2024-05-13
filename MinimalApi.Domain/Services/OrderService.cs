using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Context;
using MinimalApi.Domain.DTOs;

namespace MinimalApi.Domain.Services
{
    public class OrderService
    {
        private readonly PersistenceContext context;

        public OrderService(PersistenceContext context)
        {
            this.context = context;
        }

        public async Task<OrderDto> GetOrders(DateTime dateFrom, DateTime dateTo, List<int> customerIds, List<int> statusIds, bool? isActive)
        {
            var query = context.Order.AsQueryable();

            if (dateFrom != default && dateTo != default)
            {
                query = query.Where(o => o.OrderDate >= dateFrom && o.OrderDate <= dateTo);
            }

            if (customerIds != null && customerIds.Any())
            {
                query = query.Where(o => customerIds.Contains(o.CustomerId));
            }

            if (statusIds != null && statusIds.Any())
            {
                query = query.Where(o => statusIds.Contains(o.StatusId));
            }

            if (isActive.HasValue)
            {
                if (isActive.Value)
                {
                    query = query.Where(o => o.IsActive);
                }
                else
                {
                    query = query.Where(o => !o.IsActive);
                }
            }

            var orderDTO = await query
                .Select(o => new OrderDto
                {
                    OrderId = o.Id,
                    CustomerId = o.CustomerId,
                    StatusId = o.StatusId,
                    OrderDate = o.OrderDate,
                    IsActive = o.IsActive
                })
                .FirstOrDefaultAsync();

            return orderDTO!;
        }
    }
}
