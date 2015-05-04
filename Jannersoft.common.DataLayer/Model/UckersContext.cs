namespace Jannersoft.common.DataLayer.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UckersContext : DbContext
    {
        public UckersContext()
            : base("name=UckersContext")
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GamePlayer> GamePlayers { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerTurn> PlayerTurns { get; set; }
        public virtual DbSet<Turn> Turns { get; set; }
        public virtual DbSet<Ucker> Uckers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasMany(e => e.GamePlayers)
                .WithRequired(e => e.Game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GamePlayer>()
                .HasMany(e => e.PlayerTurns)
                .WithRequired(e => e.GamePlayer)
                .HasForeignKey(e => new { e.GameId, e.PlayerId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GamePlayer>()
                .HasMany(e => e.Uckers)
                .WithMany(e => e.GamePlayers)
                .Map(m => m.ToTable("GamePlayerUckers").MapLeftKey(new[] { "GameId", "PlayerId" }).MapRightKey("UckerId"));

            modelBuilder.Entity<Player>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.GamePlayers)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Turn>()
                .HasMany(e => e.PlayerTurns)
                .WithRequired(e => e.Turn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ucker>()
                .Property(e => e.ColourName)
                .IsFixedLength();

            modelBuilder.Entity<Ucker>()
                .Property(e => e.ColourCode)
                .IsFixedLength();
        }
    }
}
