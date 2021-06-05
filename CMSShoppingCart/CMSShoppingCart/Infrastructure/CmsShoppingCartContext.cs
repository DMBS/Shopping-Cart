using CMSShoppingCart.Models;
using Microsoft.EntityFrameworkCore;

namespace CMSShoppingCart.Infrastructure
{
    public class CmsShoppingCartContext :DbContext
    {
        public CmsShoppingCartContext(DbContextOptions<CmsShoppingCartContext> options)
            :base(options)
        {
        }

        public DbSet<Page> Pages { get; set; }
    }
}
