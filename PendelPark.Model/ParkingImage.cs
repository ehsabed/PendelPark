using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PendelPark.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ParkingImage
    {
        /// <summary>
        /// Gets or sets the internal identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the parking identifier.
        /// </summary>
        /// <value>
        /// The parking identifier.
        /// </value>
        [Required]
        public int ParkingId { get; set; }


        /// <summary>
        /// Gets or sets the image URI.
        /// </summary>
        /// <value>
        /// The image URI.
        /// </value>
        [Required]
        public string ImageUri { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
