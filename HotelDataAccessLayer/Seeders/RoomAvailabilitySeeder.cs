using HotelDataAccessLayer.Concrate;
using HotelEntityLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDataAccessLayer.Seeders
{
    public class RoomAvailabilitySeeder
    {
        public static void SeedInitialAvailability(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HotelContext>();

            var roomTypes = context.RoomTypes.ToList();

            DateTime today = DateTime.Today;
            DateTime endDate = today.AddMonths(3);

            foreach (var roomType in roomTypes)
            {
                for (DateTime date = today; date <= endDate; date = date.AddDays(1))
                {
                    // Aynı oda tipi ve gün için kayıt varsa geç
                    bool exists = context.RoomAvailabilities.Any(x =>
                        x.RoomTypeId == roomType.RoomTypeId &&
                        x.Date == date);

                    if (!exists)
                    {
                        context.RoomAvailabilities.Add(new RoomAvailability
                        {
                            RoomTypeId = roomType.RoomTypeId,
                            Date = date,
                            IsAvailableForSale = true,
                            RemainingQuota = roomType.AvailableRoomCount // ya da başka bir varsayılan
                        });
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
