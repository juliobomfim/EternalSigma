using jbDEV_Eternal.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace jbDEV_Eternal.Infra.Connections
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions opts) : base(opts)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optsBuilder)
        {
            optsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CharacterMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
