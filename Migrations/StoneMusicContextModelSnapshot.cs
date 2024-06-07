﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using stone_music_backend.Data;

#nullable disable

namespace stone_music_backend.Migrations
{
    [DbContext(typeof(StoneMusicContext))]
    partial class StoneMusicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("stone_music_backend.Data.Album", b =>
                {
                    b.Property<string>("AlbumId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sAlbumId");

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("sAlBumName");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sDescription");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sUserId");

                    b.HasKey("AlbumId")
                        .HasName("PK_Album");

                    b.HasIndex("UserId");

                    b.ToTable("Album", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.AlbumGenre", b =>
                {
                    b.Property<string>("AlbumGenreId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sAlbumGenreId");

                    b.Property<string>("AlbumGenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("sAlbumGenreName");

                    b.HasKey("AlbumGenreId")
                        .HasName("PK_AlbumGenre");

                    b.ToTable("AlbumGenre", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.Album_AlbumGenre", b =>
                {
                    b.Property<string>("AlbumId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sAlbumId");

                    b.Property<string>("AlbumGenreId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sAlbumGenreId");

                    b.HasKey("AlbumId", "AlbumGenreId")
                        .HasName("PK_Album_AlbumGenre");

                    b.HasIndex("AlbumGenreId");

                    b.ToTable("Album_AlbumGenre", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.Comment", b =>
                {
                    b.Property<string>("CommentId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sCommentId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("sContent");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("TrackId")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sTrackId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sUserId");

                    b.HasKey("CommentId")
                        .HasName("PK_Comment");

                    b.HasIndex("TrackId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.Follow", b =>
                {
                    b.Property<string>("FollowerId")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FolloweeId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sFolloweeId");

                    b.HasKey("FollowerId", "FolloweeId")
                        .HasName("PK_Follow");

                    b.HasIndex("FolloweeId");

                    b.ToTable("Follow", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.History", b =>
                {
                    b.Property<string>("HistoryId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sHistoryId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("TrackId")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sTrackId");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sUserId");

                    b.HasKey("HistoryId")
                        .HasName("PK_History");

                    b.HasIndex("TrackId");

                    b.HasIndex("UserId");

                    b.ToTable("History", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.Like", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sUserId");

                    b.Property<string>("TrackId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sTrackId");

                    b.HasKey("UserId", "TrackId")
                        .HasName("PK_Like");

                    b.HasIndex("TrackId");

                    b.ToTable("Like", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.PlayList", b =>
                {
                    b.Property<string>("PlayListId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sPlayListId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sDescription");

                    b.Property<bool>("IsPrivate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("bIsPrivate");

                    b.Property<string>("PlayListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("sPlayListName");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sUserId");

                    b.HasKey("PlayListId")
                        .HasName("PK_PlayList");

                    b.HasIndex("UserId");

                    b.ToTable("PlayList", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.PlayList_Track", b =>
                {
                    b.Property<string>("PlayListId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sPlaylistId");

                    b.Property<string>("TrackId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sTrackId");

                    b.HasKey("PlayListId", "TrackId")
                        .HasName("PK_Playlist_Track");

                    b.HasIndex("TrackId");

                    b.ToTable("PlayList_Track", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.Track", b =>
                {
                    b.Property<string>("TrackId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sTrackId");

                    b.Property<string>("AlbumId")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sAlbumId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("sDescription");

                    b.Property<string>("Hashtag")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("sHashtag");

                    b.Property<bool>("IsPrivate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("bIsPrivate");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("sSource");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("sthumbnail");

                    b.Property<string>("TrackGenreId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sTrackGenreId");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("sTrackName");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sUserId");

                    b.HasKey("TrackId")
                        .HasName("PK_Track");

                    b.HasIndex("AlbumId");

                    b.HasIndex("TrackGenreId")
                        .IsUnique()
                        .HasFilter("[sTrackGenreId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Track", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.TrackGenre", b =>
                {
                    b.Property<string>("TrackGenreId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sTrackGenreId");

                    b.Property<string>("TrackGenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sTrackGenreName");

                    b.HasKey("TrackGenreId")
                        .HasName("PK_TrackGenre");

                    b.ToTable("TrackGenre", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("sUserId")
                        .HasColumnOrder(0);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("sAccount")
                        .HasColumnOrder(6);

                    b.Property<string>("Avatar")
                        .HasColumnType("varchar(30)")
                        .HasColumnName("sAvatar")
                        .HasColumnOrder(4);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("sBio")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnOrder(8)
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(30)")
                        .HasColumnName("sEmail")
                        .HasColumnOrder(3);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sFirstName")
                        .HasColumnOrder(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("sLastName")
                        .HasColumnOrder(2);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("sPassword")
                        .HasColumnOrder(7);

                    b.HasKey("UserId")
                        .HasName("PK_User");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("stone_music_backend.Data.Album", b =>
                {
                    b.HasOne("stone_music_backend.Data.User", "User")
                        .WithMany("Albums")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Album_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("stone_music_backend.Data.Album_AlbumGenre", b =>
                {
                    b.HasOne("stone_music_backend.Data.AlbumGenre", "AlbumGenre")
                        .WithMany("Album_AlbumGenres")
                        .HasForeignKey("AlbumGenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Album_AlbumGenre_AlbumGenre");

                    b.HasOne("stone_music_backend.Data.Album", "Album")
                        .WithMany("Album_AlbumGenres")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Album_AlbumGenre_Album");

                    b.Navigation("Album");

                    b.Navigation("AlbumGenre");
                });

            modelBuilder.Entity("stone_music_backend.Data.Comment", b =>
                {
                    b.HasOne("stone_music_backend.Data.Track", "Track")
                        .WithMany("Comments")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Comment_Track");

                    b.HasOne("stone_music_backend.Data.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Comment_User");

                    b.Navigation("Track");

                    b.Navigation("User");
                });

            modelBuilder.Entity("stone_music_backend.Data.Follow", b =>
                {
                    b.HasOne("stone_music_backend.Data.User", "Followee")
                        .WithMany("Followers")
                        .HasForeignKey("FolloweeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Follow_Follower_User");

                    b.HasOne("stone_music_backend.Data.User", "Follower")
                        .WithMany("Followees")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Follow_Followee_User");

                    b.Navigation("Followee");

                    b.Navigation("Follower");
                });

            modelBuilder.Entity("stone_music_backend.Data.History", b =>
                {
                    b.HasOne("stone_music_backend.Data.Track", "Track")
                        .WithMany("Histories")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_History_Track");

                    b.HasOne("stone_music_backend.Data.User", "User")
                        .WithMany("Histories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_History_User");

                    b.Navigation("Track");

                    b.Navigation("User");
                });

            modelBuilder.Entity("stone_music_backend.Data.Like", b =>
                {
                    b.HasOne("stone_music_backend.Data.Track", "Track")
                        .WithMany("Likes")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Like_Track");

                    b.HasOne("stone_music_backend.Data.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Like_User");

                    b.Navigation("Track");

                    b.Navigation("User");
                });

            modelBuilder.Entity("stone_music_backend.Data.PlayList", b =>
                {
                    b.HasOne("stone_music_backend.Data.User", "User")
                        .WithMany("PlayLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Playlist_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("stone_music_backend.Data.PlayList_Track", b =>
                {
                    b.HasOne("stone_music_backend.Data.PlayList", "PlayList")
                        .WithMany("PlayList_Tracks")
                        .HasForeignKey("PlayListId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_PlaylistTrack_Playlist");

                    b.HasOne("stone_music_backend.Data.Track", "Track")
                        .WithMany("PlayList_Tracks")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_PlaylistTrack_Track");

                    b.Navigation("PlayList");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("stone_music_backend.Data.Track", b =>
                {
                    b.HasOne("stone_music_backend.Data.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Track_Album");

                    b.HasOne("stone_music_backend.Data.TrackGenre", "TrackGenre")
                        .WithOne("Track")
                        .HasForeignKey("stone_music_backend.Data.Track", "TrackGenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("FK_Track_TrackGenre");

                    b.HasOne("stone_music_backend.Data.User", "User")
                        .WithMany("Tracks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Track_User");

                    b.Navigation("Album");

                    b.Navigation("TrackGenre");

                    b.Navigation("User");
                });

            modelBuilder.Entity("stone_music_backend.Data.Album", b =>
                {
                    b.Navigation("Album_AlbumGenres");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("stone_music_backend.Data.AlbumGenre", b =>
                {
                    b.Navigation("Album_AlbumGenres");
                });

            modelBuilder.Entity("stone_music_backend.Data.PlayList", b =>
                {
                    b.Navigation("PlayList_Tracks");
                });

            modelBuilder.Entity("stone_music_backend.Data.Track", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Histories");

                    b.Navigation("Likes");

                    b.Navigation("PlayList_Tracks");
                });

            modelBuilder.Entity("stone_music_backend.Data.TrackGenre", b =>
                {
                    b.Navigation("Track");
                });

            modelBuilder.Entity("stone_music_backend.Data.User", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Comments");

                    b.Navigation("Followees");

                    b.Navigation("Followers");

                    b.Navigation("Histories");

                    b.Navigation("Likes");

                    b.Navigation("PlayLists");

                    b.Navigation("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}
