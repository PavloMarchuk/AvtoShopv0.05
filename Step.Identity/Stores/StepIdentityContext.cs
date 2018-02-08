using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Step.Identity.Models;


namespace Step.Identity.Stores
{
    public class StepIdentityContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public StepIdentityContext(DbContextOptions<StepIdentityContext> options)
            : base(options)
        {
        }
    }
}
