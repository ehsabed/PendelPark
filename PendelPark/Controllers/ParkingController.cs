using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI;
using PendelPark.Model;
using PendelPark.Models;

namespace PendelPark.Controllers
{
    [RoutePrefix("api/Parking")]
    public class ParkingController : ApiController
    {
        private readonly string parkingService = "ParkingService/v2.1";
        private readonly string commuterService = "CommuterParkings";
        private string gbgId = string.Empty;
        private string gbgUrl = string.Empty;
        private string gbgCommuterParkingUrl = string.Empty;
        private ParkContext db = new ParkContext();

        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<Parking, ParkingDTO>> AsParkingDto =
            x => new ParkingDTO
            {
                Id = x.Id,
                Name = x.Name,
                FreeSpaces = x.FreeSpaces,
                Latitude = x.Lat,
                Longitude = x.Long,
                ParkingSpaces = x.ParkingSpaces
            };

        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<GbgParking, Parking>> AsParking =
            x => x.ToParking();

        public ParkingController()
        {
            gbgId = ConfigurationManager.AppSettings["pendelParkGbgId"];
            gbgUrl = ConfigurationManager.AppSettings["gbgDataUrl"];

            gbgCommuterParkingUrl = string.Format("{0}/{1}/{2}/", gbgUrl, parkingService, commuterService);
        }

        // GET api/Parking
        [Route("")]
        public IQueryable<ParkingDTO> GetParkings()
        {
            return db.Parkings.Select(AsParkingDto);
        }

        // POST api/Parking/updateext
        [Route("updateext")]
        [HttpPost]
        public async Task<IHttpActionResult> UpdateFromExternal()
        {
            List<GbgParking> parkings = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(gbgCommuterParkingUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string request = string.Format("{0}?format=Json", gbgId);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    parkings = await response.Content.ReadAsAsync<List<GbgParking>>();
                }
            }

            if (parkings != null)
            {
                var dbParkings = parkings.AsQueryable().Select(AsParking);
                foreach (var parking in dbParkings)
                {
                    var currentParkingId = parking.ParkingId;
                    if (db.Parkings.Any(p => p.ParkingId == currentParkingId))
                    {
                        // Update parking
                        Parking existing = await db.Parkings.SingleAsync(p => p.ParkingId == currentParkingId);
                        existing.CurrentParkingCost = parking.CurrentParkingCost;
                        existing.Distance = parking.Distance;
                        existing.ExtraInfo = parking.ExtraInfo;
                        existing.FreeSpaces = parking.FreeSpaces;
                        existing.FreeSpacesDate = parking.FreeSpacesDate;
                        //existing.Id = 0,
                        existing.Lat = parking.Lat;
                        existing.Long = parking.Long;
                        existing.MaxParkingTime = parking.MaxParkingTime;
                        existing.MaxParkingTimeLimitation = parking.MaxParkingTimeLimitation;
                        existing.Name = parking.Name;
                        existing.Owner = parking.Owner;
                        existing.ParkableLength = parking.ParkableLength;
                        existing.ParkingCharge = parking.ParkingCharge;
                        existing.ParkingCost = parking.ParkingCost;
                        //existing.ParkingId = gbg.Id,
                        //existing.ParkingImages = new Collection<ParkingImage>(),
                        existing.ParkingSpaceCount = parking.ParkingSpaceCount;
                        existing.ParkingSpaces = parking.ParkingSpaces;
                        existing.PhoneParkingCode = parking.PhoneParkingCode;
                        existing.ResidentialParkingArea = parking.ResidentialParkingArea;
                    }
                    else
                    {
                        // New parking
                        db.Parkings.Add(parking);
                    }
                }

                var dbResult = await db.SaveChangesAsync();
            }
            return Ok();
        }
    }
}