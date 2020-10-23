using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tic_tac_toe_api.Models.EntityFramework;

namespace Tic_tac_toe_api.Data
{
    public class Tic_tac_toeContext : DbContext
    {
        public Tic_tac_toeContext(DbContextOptions<Tic_tac_toeContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<GamePlayerSection> GamePlayerSections { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var converter = new ValueConverter<FigureType, string>(
            //f => f.ToString(),
            //f => (FigureType)Enum.Parse(typeof(FigureType), f));
            var converter = new EnumToStringConverter<FigureType>();
            modelBuilder
                .Entity<GamePlayer>()
                .Property(gp => gp.Figure)
                .HasConversion(converter);
            modelBuilder.Entity<GamePlayerSection>()
                .HasKey(gp => new { gp.GamePlayerId, gp.SectionId });
            //modelBuilder.Entity<GamePlayer>()
            //    .HasOne(gp => gp.Student)
            //    .WithMany(s => s.Scores)
            //    .HasForeignKey(s => s.StudentId)
            //    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Seed(new Initializer());

        }
    }
}
