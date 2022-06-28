using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDatabase.Models.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        public DbSet<ReservatorioModel> reservatorio { get; set; }
        public DbSet<SensorNivelModel> sensor_nivel { get; set; }
        public DbSet<SensorVazaoModel> sensor_vazao { get; set; }
        public DbSet<UsuarioModel> usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioModel>().HasMany(u => u.Reservatorios);
            modelBuilder.Entity<ReservatorioModel>().HasOne(r => r.usuario);
            modelBuilder.Entity<ReservatorioModel>().HasMany(r => r.SensorNivel);
            modelBuilder.Entity<ReservatorioModel>().HasMany(r => r.SensorVazao);
            modelBuilder.Entity<SensorNivelModel>().HasOne(s => s.Reservatorio);
            modelBuilder.Entity<SensorVazaoModel>().HasOne(s => s.reservatorio);
        }
    }
}
