using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CynfoApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser
    // class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        internal Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager userManager)
        {
            throw new NotImplementedException();
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer(new MySqlInitializer());
        }

        public ApplicationDbContext()
          : base("DefaultConnection")
        {
        }

        internal static IDisposable Create()
        {
            throw new NotImplementedException();
        }
    }
}