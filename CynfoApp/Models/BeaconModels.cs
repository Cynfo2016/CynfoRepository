﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CynfoApp.Models
{
    [Table("cynfodb.beacon")]
    public partial class BeaconModels
    {
        public int idBeacon { get; set; }

        public string beaconAddress { get; set; }

        public int beaconMajor { get; set; }

        public int beaconMinor { get; set; }

        public string Place_idPlace { get; set; }

    }

    public class DefaultConnectioncontext : DbContext
    {
        public Task<adModels> ad { get; internal set; }
        public Task<object> Ads { get; internal set; }
        public DbSet<BeaconModels> beacon { get; set; }
    }
}