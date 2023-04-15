using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MusicStreaming.Entitis
{
    public partial class MusicStreamingContext : DbContext
    {
        public MusicStreamingContext()
        {
        }

        public MusicStreamingContext(DbContextOptions<MusicStreamingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountMusic> AccountMusics { get; set; }
        public virtual DbSet<Accout> Accouts { get; set; }
        public virtual DbSet<Music> Musics { get; set; }
        public virtual DbSet<Singer> Singers { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ADMIN\\SQLEXPRESS;Database=MusicStreaming;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountMusic>(entity =>
            {
                entity.ToTable("Account_Music");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdAccount).HasColumnName("Id_Account");

                entity.Property(e => e.IdMusic).HasColumnName("Id_Music");
            });

            modelBuilder.Entity<Accout>(entity =>
            {
                entity.ToTable("Accout");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Music>(entity =>
            {
                entity.ToTable("Music");

                entity.Property(e => e.CreateDate).HasMaxLength(50);

                entity.Property(e => e.IdSinger).HasColumnName("Id_Singer");

                entity.Property(e => e.IdType).HasColumnName("Id_Type");

                entity.Property(e => e.ImgInfo)
                    .HasMaxLength(50)
                    .HasColumnName("Img_Info");

                entity.Property(e => e.LinkFile).HasMaxLength(50);

                entity.Property(e => e.NameMusic).HasMaxLength(50);
            });

            modelBuilder.Entity<Singer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Singer");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ImgInfo)
                    .HasMaxLength(50)
                    .HasColumnName("Img_Info");

                entity.Property(e => e.NameSinger).HasMaxLength(50);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.NameType).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
