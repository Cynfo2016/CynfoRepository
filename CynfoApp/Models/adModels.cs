using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace CynfoApp.Models
{
    [Table("cynfodb.ad")]
    public partial class adModels
    {
        public int idad { get; set; }

        public string adTitle { get; set; }

        public string adDescription { get; set; }

        public string adMediaUrl { get; set; }

        [Column(TypeName = "date")]
        public DateTime? adPublishedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? adFinishedDate { get; set; }

        public int adMinor { get; set; }

        public string adArea { get; set; }


        public class DefaultConnectioncontext : DbContext
        {
            public DbSet<adModels> ad { get; set; }
        }
    }
}