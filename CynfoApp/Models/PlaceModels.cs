using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CynfoApp.Models
{
    [Table("cynfodb.beacon")]
    public partial class PlaceModels
    {
        public int idPlace { get; set; }

        public string placeName { get; set; }

        public string placeDescription { get; set; }

        public string placeLogo { get; set; }

        public int placeMajor { get; set; }

        public string placeAddress { get; set; }

        public string placecontact { get; set; }


        public class DefaultConnectioncontext : DbContext
        {
            public DbSet<PlaceModels> beacon { get; set; }
        }

    }
}