using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using CMPH_Finance.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CMPH_Financial.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? HouseholdId { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string DisplayName { get; set; }
        public string ProfileImagePath { get; set; }

        public virtual Household Household { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }



        public ApplicationUser()
        {
            Transactions = new HashSet<Transaction>();
            Notifications = new HashSet<Notification>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            //userIdentity.AddClaim(new Claim("FirstName", this.FirstName));
            //userIdentity.AddClaim(new Claim("LastName", this.LastName));
            //userIdentity.AddClaim(new Claim("DisplayName", this.DisplayName));
            //userIdentity.AddClaim(new Claim("UserName", this.UserName));
            //userIdentity.AddClaim(new Claim("ProfileImagePath", this.ProfileImagePath ?? ""));
            //userIdentity.AddClaim(new Claim("FullName", $"{this.FirstName}{this.LastName}"));

            // Add custom user claims here      
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CMPH_Finance.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<CMPH_Finance.Models.Budget> Budgets { get; set; }

        public System.Data.Entity.DbSet<CMPH_Finance.Models.BudgetItem> BudgetItems { get; set; }

        public System.Data.Entity.DbSet<CMPH_Finance.Models.TransactionType> TransactionTypes { get; set; }

        public System.Data.Entity.DbSet<CMPH_Finance.Models.Household> Households { get; set; }

        public System.Data.Entity.DbSet<CMPH_Finance.Models.Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<CMPH_Finance.Models.Invitation> Invitations { get; set; }

        public System.Data.Entity.DbSet<CMPH_Finance.Models.Notification> Notifications { get; set; }

    }
}