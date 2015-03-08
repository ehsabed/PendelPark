using System.Collections.ObjectModel;
using PendelPark.Model;

namespace PendelPark.Models
{
    public static class Extensions
    {
        /// <summary>
        /// Convert to <see cref="Parking"/>.
        /// </summary>
        /// <param name="gbg">The <see cref="GbgParking"/> object.</param>
        /// <returns></returns>
        public static Parking ToParking(this GbgParking gbg)
        {
            return new Parking
            {
                CurrentParkingCost = gbg.CurrentParkingCost,
                Distance = gbg.Distance,
                ExtraInfo = gbg.ExtraInfo,
                FreeSpaces = gbg.FreeSpaces,
                FreeSpacesDate = gbg.FreeSpacesDate,
                Id = 0,
                Lat = gbg.Lat,
                Long = gbg.Long,
                MaxParkingTime = gbg.MaxParkingTime,
                MaxParkingTimeLimitation = gbg.MaxParkingTimeLimitation,
                Name = gbg.Name,
                Owner = gbg.Owner,
                ParkableLength = gbg.ParkableLength,
                ParkingCharge = gbg.ParkingCharge,
                ParkingCost = gbg.ParkingCost,
                ParkingId = gbg.Id,
                ParkingImages = new Collection<ParkingImage>(),
                ParkingSpaceCount = gbg.ParkingSpaceCount,
                ParkingSpaces = gbg.ParkingSpaces,
                PhoneParkingCode = gbg.PhoneParkingCode,
                ResidentialParkingArea = gbg.ResidentialParkingArea
            };
        }
    }
}