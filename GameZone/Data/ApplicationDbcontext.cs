using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class ApplicationDbcontext:DbContext

    {

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options) { }

    }
}
