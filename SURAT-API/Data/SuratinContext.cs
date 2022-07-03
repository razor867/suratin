using SURAT_API.Models;
using Microsoft.EntityFrameworkCore;

namespace SURAT_API.Data
{
    public class SuratinContext : DbContext
    {
        public SuratinContext(DbContextOptions<SuratinContext> options) : base(options) { }

        public DbSet<surat_masuk> surat_masuk { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<surat_masuk>().HasKey(k => new { k.Id });
        }
    }
}