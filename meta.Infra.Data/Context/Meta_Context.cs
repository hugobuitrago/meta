using meta.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.Infra.Data.Context
{
    public class Meta_Context : DbContext
    {
        public Meta_Context(DbContextOptions<Meta_Context> options) : base (options)
        {

        }

        #region DBSets
        public virtual DbSet<Caminhao> Caminhao { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caminhao>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
