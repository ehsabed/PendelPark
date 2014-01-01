using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PendelPark.Model
{
    public class ParkContext : IdentityDbContext
    {
        public DbSet<Parking> Parkings { get; set; }

        public ParkContext()
            : base("DefaultConnection")
        {

        }
    }
}
