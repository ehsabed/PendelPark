using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PendelPark.Models
{
    public class ParkingDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the free spaces.
        /// Antal ledig platster just nu.
        /// </summary>
        /// <value>
        /// The free spaces.
        /// </value>
        public int? FreeSpaces { get; set; }

        /// <summary>
        /// Gets or sets the lat.
        /// Latitud i WGS84
        /// </summary>
        /// <value>
        /// The lat.
        /// </value>
        public string Latitude { get; set; }

        /// <summary>
        /// Gets or sets the long.
        /// Longitud i WGS84
        /// </summary>
        /// <value>
        /// The long.
        /// </value>
        public string Longitude { get; set; }

        /// <summary>
        /// Gets or sets the parking spaces.
        /// Totalt antal parkeringsplatser
        /// </summary>
        /// <value>
        /// The parking spaces.
        /// </value>
        public int? ParkingSpaces { get; set; }
    }
}