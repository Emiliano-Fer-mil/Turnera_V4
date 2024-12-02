namespace Turnera_V4.Context
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Turnera_V4.Models;


    public class TurneraBDContext : DbContext
    {
        public TurneraBDContext(DbContextOptions<TurneraBDContext> options) : base(options) { }
    
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Asociado> Pacientes { get; set; }
        public DbSet<Cita> Turnos { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>()
                .HasOne(t => t.Medico)
                .WithMany(m => m.Citas)
                .HasForeignKey(t => t.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cita>()
                .HasOne(t => t.Asociado)
                .WithMany(p => p.Citas)
                .HasForeignKey(t => t.AsociadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        



    }
}
