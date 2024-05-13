using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Context;
using MinimalApi.Domain.DTOs;

namespace MinimalApi.Domain.Services
{
    public class VehicleService
    {
        private readonly PersistenceContext context;

        public VehicleService(PersistenceContext context)
        {
            this.context = context;
        }

        public async Task<List<VehicleDto>> GetVehicles()
        {
            var query = from v in context.Vehicle
                        join l in context.Location on v.LocationId equals l.Id
                        join c in context.Customer on v.CustomerId equals c.Id
                        join bv in context.BuyerVehicle on v.Id equals bv.VehicleId
                        join b in context.Buyer on bv.BuyerId equals b.Id

                        let latestHistory = context.BuyerVehicleHistory
                            .OrderByDescending(h => h.CreatedDate)
                            .Where(h => h.BuyerVehicleId == bv.Id)
                            .FirstOrDefault()

                        where bv.IsCurrent == true
                        select new VehicleDto()
                        {
                            Year = v.Year,
                            Brand = v.Brand,
                            Model = v.Model,
                            SubModel = v.SubModel,
                            ZipCode = l.ZipCode,
                            CustomerName = c.Name,
                            Amount = bv.Amount,
                            BuyerName = b.Name,
                            Status = latestHistory.Status,
                            CreatedDate = latestHistory.CreatedDate
                        };
            
            return await query.ToListAsync();
        }
    }
}
