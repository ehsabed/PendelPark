using System;

namespace PendelPark.Models
{
    /// <summary>
    /// Represents the Parking-object returned fromn the external service.
    /// </summary>
    public class GbgParking
    {
        /// <summary>
        /// Unikt id för parkeringen, om det är en kommunal parkering är det dess LTF-nummer
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// Namn på parkeringen, oftast en adress eller namnet på P-huset
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// Anger vem som äger parkeringen, mer information om ägaren kan fås via metoden ParikingOwners
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the free spaces.
        /// Antal ledig platster just nu.
        /// </summary>
        /// <value>
        /// The free spaces.
        /// </value>
        public int? FreeSpaces { get; set; }

        /// <summary>
        /// Gets or sets the free spaces date.
        /// När antal lediga platser senast uppdaterades.
        /// </summary>
        /// <value>
        /// The free spaces date.
        /// </value>
        public DateTime? FreeSpacesDate { get; set; }

        /// <summary>
        /// Gets or sets the parking spaces.
        /// Totalt antal parkeringsplatser
        /// </summary>
        /// <value>
        /// The parking spaces.
        /// </value>
        public int? ParkingSpaces { get; set; }

        /// <summary>
        /// Gets or sets the length of the parkable.
        /// Antal meter fickparkeringar
        /// </summary>
        /// <value>
        /// The length of the parkable.
        /// </value>
        public int? ParkableLength { get; set; }

        /// <summary>
        /// Gets or sets the parking space count.
        /// Antal P-rutor
        /// </summary>
        /// <value>
        /// The parking space count.
        /// </value>
        public int? ParkingSpaceCount { get; set; }

        /// <summary>
        /// Gets or sets the phone parking code.
        /// Telefonparkeringskod 
        /// </summary>
        /// <value>
        /// The phone parking code.
        /// </value>
        public string PhoneParkingCode { get; set; }

        /// <summary>
        /// Gets or sets the parking charge.
        /// Taxa
        /// </summary>
        /// <value>
        /// The parking charge.
        /// </value>
        public string ParkingCharge { get; set; }

        /// <summary>
        /// Gets or sets the parking cost.
        /// Kostnad i klartext
        /// </summary>
        /// <value>
        /// The parking cost.
        /// </value>
        public string ParkingCost { get; set; }

        /// <summary>
        /// Gets or sets the current parking cost.
        /// Kostnad per timme att parkera just nu
        /// </summary>
        /// <value>
        /// The current parking cost.
        /// </value>
        public string CurrentParkingCost { get; set; }

        /// <summary>
        /// Gets or sets the maximum parking time.
        /// Max tillåten P-tid
        /// </summary>
        /// <value>
        /// The maximum parking time.
        /// </value>
        public string MaxParkingTime { get; set; }

        /// <summary>
        /// Gets or sets the maximum parking time limitation.
        /// Ytterligare villkor till max tillåten P-tid
        /// </summary>
        /// <value>
        /// The maximum parking time limitation.
        /// </value>
        public string MaxParkingTimeLimitation { get; set; }

        /// <summary>
        /// Gets or sets the residential parking area.
        /// Boendeparkering, t.ex M4
        /// </summary>
        /// <value>
        /// The residential parking area.
        /// </value>
        public string ResidentialParkingArea { get; set; }

        /// <summary>
        /// Gets or sets the extra information.
        /// Övrig info, t.ex. städzon mm
        /// </summary>
        /// <value>
        /// The extra information.
        /// </value>
        public string ExtraInfo { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// Avstånd i meter från aktuell position (returneras endast om egen position skickats in)
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public string Distance { get; set; }

        /// <summary>
        /// Gets or sets the lat.
        /// Latitud i WGS84
        /// </summary>
        /// <value>
        /// The lat.
        /// </value>
        public string Lat { get; set; }

        /// <summary>
        /// Gets or sets the long.
        /// Longitud i WGS84
        /// </summary>
        /// <value>
        /// The long.
        /// </value>
        public string Long { get; set; }
    }
}