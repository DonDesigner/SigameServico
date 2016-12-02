namespace Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Entities;

    public partial class BDContext : DbContext
    {
        public BDContext()
            : base("name=BDContext")
        {
        }

        public virtual DbSet<ArteFinal> ArteFinal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArteFinal>()
                .Property(e => e.Arquivo)
                .IsUnicode(false);

            modelBuilder.Entity<ArteFinal>()
                .Property(e => e.Trabalho)
                .IsUnicode(false);
        }
    }
}
