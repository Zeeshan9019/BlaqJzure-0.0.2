using BlaqJzure.Domain.Categories;
using BlaqJzure.Domain.Costommers;
using BlaqJzure.Domain.Products;
using BlaqJzure.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlaqJzure.Repository
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Custommer> Custommers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
