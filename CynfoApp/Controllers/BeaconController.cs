using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CynfoApp.Models;
//using CynfoApp.azureUtils;

namespace CynfoApp.Controllers
{
    public class BeaconController : Controller
    {
        // GET: Beacon
        public ActionResult Index()
        {
            return View();
        }
    }
}