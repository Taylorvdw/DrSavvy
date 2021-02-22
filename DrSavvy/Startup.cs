using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using DrSavvy.Models;
using DrSavvy.Controllers;

[assembly: OwinStartupAttribute(typeof(DrSavvy.Startup))]

namespace DrSavvy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
            createRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login    
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            try
            {
                // In Startup iam creating first Admin Role and creating a default Admin User     
                if (!roleManager.RoleExists("Admin"))
                {

                    // first we create Admin role    
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website                   

                    var user = new ApplicationUser();
                    user.UserName = "IsDev";
                    user.Email = "calvinmunava1@gmail.com";

                    string userPWD = "Twennywan21";

                    var chkUser = UserManager.Create(user, userPWD);

                    //Add default User to Role Admin    
                    if (chkUser.Succeeded)
                    {
                        var result1 = UserManager.AddToRole(user.Id, "Admin");

                    }
                }

                // creating Creating Owner role     
                if (!roleManager.RoleExists("Owner"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Owner";
                    roleManager.Create(role);

                }
                // creating Creating Bookkeeper role     
                if (!roleManager.RoleExists("BookKeeper"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "BookKeeper";
                    roleManager.Create(role);

                }

                // creating Creating Receptionist role     
                if (!roleManager.RoleExists("Receptionist"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Receptionist";
                    roleManager.Create(role);

                }

                // creating Creating Nurse role     
                if (!roleManager.RoleExists("Nurse"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Nurse";
                    roleManager.Create(role);

                }

                // creating Creating Nurse role     
                if (!roleManager.RoleExists("User"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "User";
                    roleManager.Create(role);

                }
            }
            catch
            {
                
            }

        }
    }
}