using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BaddyMatchMaker.Models
{
    public partial class BaddyMatchMakerContext : DbContext
    {
        public BaddyMatchMakerContext()
        {
        }

        public BaddyMatchMakerContext(DbContextOptions<BaddyMatchMakerContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=BaddyMatchMaker;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.Property(e => e.ClubId).HasColumnName("clubId");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.MatchId).HasColumnName("matchId");

                entity.Property(e => e.CourtNumber).HasColumnName("courtNumber");

                entity.Property(e => e.RoundId).HasColumnName("roundId");

                entity.HasOne(d => d.Round)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.RoundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Round");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.ClubId).HasColumnName("clubId");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sex")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_Club");
            });

            modelBuilder.Entity<PlayerMatch>(entity =>
            {
                entity.ToTable("PlayerMatch");

                entity.HasIndex(e => new { e.MatchId, e.PlayerId }, "IX_PlayerMatch")
                    .IsUnique();

                entity.Property(e => e.PlayerMatchId).HasColumnName("playerMatchId");

                entity.Property(e => e.MatchId).HasColumnName("matchId");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.PlayerMatches)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerMatch_Match");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerMatches)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerMatch_Player");
            });

            modelBuilder.Entity<Round>(entity =>
            {
                entity.ToTable("Round");

                entity.Property(e => e.RoundId).HasColumnName("roundId");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("endTime");

                entity.Property(e => e.RoundNumber).HasColumnName("roundNumber");

                entity.Property(e => e.SessionId).HasColumnName("sessionId");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");

                entity.Property(e => e.CourtsAvailable).HasColumnName("courtsAvailable");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Rounds)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Round_Session");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.Property(e => e.SessionId).HasColumnName("sessionId");

                entity.Property(e => e.ClubId).HasColumnName("clubId");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("endTime");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");

                entity.Property(e => e.VenueId).HasColumnName("venueId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Club");

                entity.HasOne(d => d.Venue)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.VenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Venue");
            });

            modelBuilder.Entity<SessionPlayer>(entity =>
            {
                entity.ToTable("SessionPlayer");

                entity.HasIndex(e => new { e.SessionId, e.PlayerId }, "IX_SessionPlayer")
                    .IsUnique();

                entity.Property(e => e.SessionPlayerId).HasColumnName("sessionPlayerId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.SessionId).HasColumnName("sessionId");

                entity.Property(e => e.SignInTime)
                    .HasColumnType("datetime")
                    .HasColumnName("signInTime");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.SessionPlayers)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionPlayer_Player");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionPlayers)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionPlayer_Session");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.ClubId)
                    .HasName("PK_Settings");

                entity.ToTable("Setting");

                entity.HasKey(e => e.ClubId);

                entity.Property(e => e.ClubId)
                    .ValueGeneratedNever()
                    .HasColumnName("clubId");

                entity.Property(e => e.IgnoreSex).HasColumnName("ignoreSex");

                entity.Property(e => e.MatchDuration).HasColumnName("matchDuration");

                entity.Property(e => e.PrioritizeMixed).HasColumnName("prioritizeMixed");

                entity.Property(e => e.SinglesMode).HasColumnName("singlesMode");

                entity.HasOne(d => d.Club)
                    .WithOne(p => p.Setting)
                    .HasForeignKey<Setting>(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Settings_Club");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.ToTable("Venue");

                entity.Property(e => e.VenueId).HasColumnName("venueId");

                entity.Property(e => e.Address)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.NumberOfCourts).HasColumnName("numberOfCourts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
