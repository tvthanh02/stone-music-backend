
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace stone_music_backend.Data
{

    public class StoneMusicContext : DbContext
    {
        public StoneMusicContext() : base()
        {

        }

        public virtual DbSet<PlayList_Track> PlayList_Tracks { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        public virtual DbSet<TrackGenre> TrackGenres { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<AlbumGenre> AlbumGenres { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Follow> Follows { get; set; }

        public virtual DbSet<History> Histories { get; set; }

        public virtual DbSet<Like> Likes { get; set; }

        public virtual DbSet<PlayList> PlayLists { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<PlayListGenre> PlayListGenres { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var configSection = configBuilder.GetSection("ConnectionStrings");
            var connectionString = configSection["SQLServerConnection"] ?? "";
            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            // PlaylistTrack

            modelBuilder.Entity<PlayList_Track>(entity =>
           {
               entity.HasKey(plt => new { plt.PlayListId, plt.TrackId }).HasName("PK_Playlist_Track");
               entity.HasOne(plt => plt.PlayList).WithMany(pl => pl.PlayList_Tracks).HasForeignKey(plt => plt.PlayListId).HasConstraintName("FK_PlaylistTrack_Playlist").OnDelete(DeleteBehavior.Restrict);
               entity.HasOne(plt => plt.Track).WithMany(t => t.PlayList_Tracks).HasForeignKey(plt => plt.TrackId).HasConstraintName("FK_PlaylistTrack_Track").OnDelete(DeleteBehavior.Restrict);

               entity.ToTable("PlayList_Track");

               // property

               entity.Property(p => p.PlayListId).HasColumnName("sPlaylistId").HasColumnType("varchar(50)").IsRequired();
               entity.Property(p => p.TrackId).HasColumnName("sTrackId").HasColumnType("varchar(50)").IsRequired();

           });

            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId).HasName("PK_User");
                entity.HasMany(u => u.Albums).WithOne(al => al.User).HasForeignKey(al => al.UserId).HasConstraintName("FK_Album_User");
                entity.HasMany(u => u.Tracks).WithOne(t => t.User).HasForeignKey(t => t.UserId).HasConstraintName("FK_Track_User");
                entity.HasMany(u => u.PlayLists).WithOne(pl => pl.User).HasForeignKey(pl => pl.UserId).HasConstraintName("FK_Playlist_User");
                entity.HasMany(u => u.Likes).WithOne(l => l.User).HasForeignKey(l => l.UserId).HasConstraintName("FK_Like_User");
                entity.HasMany(u => u.Histories).WithOne(h => h.User).HasForeignKey(h => h.UserId).HasConstraintName("FK_History_User");
                entity.HasMany(u => u.Comments).WithOne(c => c.User).HasForeignKey(c => c.UserId).HasConstraintName("FK_Comment_User");
                entity.HasMany(u => u.Followers).WithOne(f => f.Followee).HasForeignKey(f => f.FolloweeId).HasConstraintName("FK_Follow_Follower_User").OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(u => u.Followees).WithOne(f => f.Follower).HasForeignKey(f => f.FollowerId).HasConstraintName("FK_Follow_Followee_User").OnDelete(DeleteBehavior.NoAction);
                entity.ToTable("User");

                //property

                entity.Property(p => p.UserId).HasColumnName("sUserId").HasColumnType("varchar(50)").HasColumnOrder(0).IsRequired();
                entity.Property(p => p.FirstName).HasColumnName("sFirstName").HasColumnType("nvarchar(50)").HasColumnOrder(1).IsRequired();
                entity.Property(p => p.LastName).HasColumnName("sLastName").HasColumnType("nvarchar(50)").HasColumnOrder(2).IsRequired();
                entity.Property(p => p.Email).HasColumnName("sEmail").HasColumnType("varchar(30)").HasColumnOrder(3);
                entity.Property(p => p.Avatar).HasColumnName("sAvatar").HasColumnType("varchar(30)").HasColumnOrder(4);
                entity.Property(p => p.Bio).HasColumnName("sBio").HasColumnType("nvarchar(100)").HasColumnOrder(5);
                entity.Property(p => p.Account).HasColumnName("sAccount").HasColumnType("varchar(20)").HasColumnOrder(6).IsRequired();
                entity.Property(p => p.Password).HasColumnName("sPassword").HasColumnType("varchar(20)").HasColumnOrder(7).IsRequired();
                entity.Property(p => p.CreatedAt).HasColumnType("datetime").HasColumnOrder(8).IsRequired().HasDefaultValueSql("GETDATE()");

            });


            // Track
            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(t => t.TrackId).HasName("PK_Track");
                entity.HasOne(t => t.Album).WithMany(al => al.Tracks).HasForeignKey(t => t.AlbumId).HasConstraintName("FK_Track_Album").OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(t => t.TrackGenre).WithMany(tg => tg.Tracks).HasForeignKey(t => t.TrackGenreId).HasConstraintName("FK_Track_TrackGenre").OnDelete(DeleteBehavior.Restrict); ;
                entity.HasMany(t => t.Likes).WithOne(l => l.Track).HasForeignKey(l => l.TrackId).HasConstraintName("FK_Like_Track").OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(t => t.Histories).WithOne(h => h.Track).HasForeignKey(h => h.TrackId).HasConstraintName("FK_History_Track").OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(t => t.Comments).WithOne(c => c.Track).HasForeignKey(c => c.TrackId).HasConstraintName("FK_Comment_Track").OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("Track");

                // property 

                entity.Property(p => p.TrackId).HasColumnName("sTrackId").HasColumnType("varchar(50)").IsRequired();
                entity.Property(p => p.TrackName).HasColumnName("sTrackName").HasColumnType("nvarchar(100)").IsRequired();
                entity.Property(p => p.Description).HasColumnName("sDescription");
                entity.Property(p => p.Thumbnail).HasColumnName("sthumbnail").HasColumnType("varchar(100)").IsRequired();
                entity.Property(p => p.Source).HasColumnName("sSource").HasColumnType("varchar(30)").IsRequired();
                entity.Property(p => p.Hashtag).HasColumnName("sHashtag").HasColumnType("varchar(100)");
                entity.Property(p => p.IsPrivate).HasColumnName("bIsPrivate").HasColumnType("bit").IsRequired().HasDefaultValue(0);
                entity.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()");
                entity.Property(p => p.AlbumId).HasColumnName("sAlbumId").HasColumnType("varchar(50)");
                entity.Property(p => p.UserId).HasColumnName("sUserId").HasColumnType("varchar(50)").IsRequired();
                entity.Property(p => p.TrackGenreId).HasColumnName("sTrackGenreId").HasColumnType("varchar(50)");


            });

            // Album 
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(al => al.AlbumId).HasName("PK_Album");
                entity.HasOne(al => al.AlbumGenre).WithMany(alg => alg.Albums).HasForeignKey(al => al.AlbumGenreId).HasConstraintName("FK_Album_AlbumGenre").OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("Album");

                // property

                entity.Property(p => p.AlbumId).HasColumnName("sAlbumId").HasColumnType("varchar(50)").IsRequired();
                entity.Property(p => p.AlbumName).HasColumnName("sAlBumName").HasColumnType("nvarchar(100)").IsRequired();
                entity.Property(p => p.Description).HasColumnName("sDescription");
                entity.Property(p => p.UserId).HasColumnName("sUserId").HasColumnType("varchar(50)").IsRequired();

            });

            // AlbumGenre

            modelBuilder.Entity<AlbumGenre>(entity =>
           {
               entity.HasKey(alg => alg.AlbumGenreId).HasName("PK_AlbumGenre");
               entity.HasIndex(alg => alg.AlbumGenreName).IsUnique();
               entity.ToTable("AlbumGenre");

               // property

               entity.Property(p => p.AlbumGenreId).HasColumnName("sAlbumGenreId").HasColumnType("varchar(50)").IsRequired();
               entity.Property(p => p.AlbumGenreName).HasColumnName("sAlbumGenreName").HasColumnType("nvarchar(30)").IsRequired();

           });

            // comment

            modelBuilder.Entity<Comment>(entity =>
           {
               entity.HasKey(c => c.CommentId).HasName("PK_Comment");
               entity.ToTable("Comment");

               // property

               entity.Property(p => p.CommentId).HasColumnName("sCommentId").HasColumnType("varchar(50)").IsRequired();
               entity.Property(p => p.Content).HasColumnName("sContent").HasColumnType("nvarchar(100)").IsRequired();
               entity.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()");
               entity.Property(p => p.UpdatedAt).HasColumnType("datetime");
               entity.Property(p => p.UserId).HasColumnName("sUserId").HasColumnType("varchar(50)").IsRequired();
               entity.Property(p => p.TrackId).HasColumnName("sTrackId").HasColumnType("varchar(50)").IsRequired();


           });

            // Follow

            modelBuilder.Entity<Follow>(entity =>
          {
              entity.HasKey(f => new { f.FollowerId, f.FolloweeId }).HasName("PK_Follow");
              entity.ToTable("Follow");

              // property

              entity.Property(p => p.FolloweeId).HasColumnName("sFollowerId").HasColumnType("varchar(50)").IsRequired();
              entity.Property(p => p.FolloweeId).HasColumnName("sFolloweeId").HasColumnType("varchar(50)").IsRequired();


          });

            // History

            modelBuilder.Entity<History>(entity =>
          {
              entity.HasKey(h => h.HistoryId).HasName("PK_History");
              entity.ToTable("History");

              // property

              entity.Property(p => p.HistoryId).HasColumnName("sHistoryId").HasColumnType("varchar(50)").IsRequired();
              entity.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()");
              entity.Property(p => p.UpdatedAt).HasColumnType("datetime");
              entity.Property(p => p.UserId).HasColumnName("sUserId").HasColumnType("varchar(50)").IsRequired();
              entity.Property(p => p.TrackId).HasColumnName("sTrackId").HasColumnType("varchar(50)").IsRequired();

          });

            // Like

            modelBuilder.Entity<Like>(entity =>
           {
               entity.HasKey(l => new { l.UserId, l.TrackId }).HasName("PK_Like");
               entity.ToTable("Like");

               // property

               entity.Property(p => p.UserId).HasColumnName("sUserId").HasColumnType("varchar(50)").IsRequired();
               entity.Property(p => p.TrackId).HasColumnName("sTrackId").HasColumnType("varchar(50)").IsRequired();


           });

            // PlayList 

            modelBuilder.Entity<PlayList>(entity =>
          {
              entity.HasKey(pl => pl.PlayListId).HasName("PK_PlayList");
              entity.HasOne(pl => pl.PlayListGenre).WithMany(plg => plg.PlayLists).HasForeignKey(pl => pl.PlayListGenreId).HasConstraintName("FK_PlayList_PlayListGenre").OnDelete(DeleteBehavior.Restrict);
              entity.ToTable("PlayList");

              // property

              entity.Property(p => p.PlayListId).HasColumnName("sPlayListId").HasColumnType("varchar(50)").IsRequired();
              entity.Property(p => p.PlayListName).HasColumnName("sPlayListName").HasColumnType("nvarchar(100)").IsRequired();
              entity.Property(p => p.Description).HasColumnName("sDescription");
              entity.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()");
              entity.Property(p => p.IsPrivate).HasColumnName("bIsPrivate").HasColumnType("bit").IsRequired().HasDefaultValue(0);
              entity.Property(p => p.UserId).HasColumnName("sUserId").HasColumnType("varchar(50)").IsRequired();

          });

            // TrackGenre


            modelBuilder.Entity<TrackGenre>(entity =>
           {
               entity.HasKey(tg => tg.TrackGenreId).HasName("PK_TrackGenre");
               entity.HasIndex(tg => tg.TrackGenreName).IsUnique();
               entity.ToTable("TrackGenre");

               // property

               entity.Property(p => p.TrackGenreId).HasColumnName("sTrackGenreId").HasColumnType("varchar(50)").IsRequired();
               entity.Property(p => p.TrackGenreName).HasColumnName("sTrackGenreName").HasColumnType("nvarchar(50)").IsRequired();

           });


            // PlayListGenre


            modelBuilder.Entity<PlayListGenre>(entity =>
           {
               entity.HasKey(plg => plg.PlayListGenreId).HasName("PK_PlayListGenre");
               entity.HasIndex(plg => plg.PlayListGenreName).IsUnique();
               entity.ToTable("PlayListGerne");

               // property

               entity.Property(p => p.PlayListGenreId).HasColumnName("sPlayListGenreId").HasColumnType("varchar(50)").IsRequired();
               entity.Property(p => p.PlayListGenreName).HasColumnName("sPlayListGenreName").HasColumnType("nvarchar(100)").IsRequired();

           });



        }

    }
}