using HotelScheduleRoom.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelScheduleRoom.Infra.Context
{
    public class HotelScheduleDbContext : DbContext
    {
        public HotelScheduleDbContext(DbContextOptions<HotelScheduleDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationEnt>().ToTable("tbReservation");
            modelBuilder.Entity<ReservationEnt>().HasKey(x => x.id);
            modelBuilder.Entity<ReservationEnt>().Property(i => i.Name).HasColumnName("name");
            modelBuilder.Entity<ReservationEnt>().Property(p => p.BeginDate).HasColumnName("begin");
            modelBuilder.Entity<ReservationEnt>().Property(p => p.EndDate).HasColumnName("end");


            modelBuilder.Entity<ReservationEnt>(entity => {
                entity.HasKey(k => k.id);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
