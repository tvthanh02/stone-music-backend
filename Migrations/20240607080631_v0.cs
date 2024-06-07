using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stone_music_backend.Migrations
{
    /// <inheritdoc />
    public partial class v0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumGenre",
                columns: table => new
                {
                    sAlbumGenreId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sAlbumGenreName = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumGenre", x => x.sAlbumGenreId);
                });

            migrationBuilder.CreateTable(
                name: "TrackGenre",
                columns: table => new
                {
                    sTrackGenreId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackGenreName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackGenre", x => x.sTrackGenreId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sFirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    sLastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    sEmail = table.Column<string>(type: "varchar(30)", nullable: true),
                    sAvatar = table.Column<string>(type: "varchar(30)", nullable: true),
                    sBio = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    sAccount = table.Column<string>(type: "varchar(20)", nullable: false),
                    sPassword = table.Column<string>(type: "varchar(20)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.sUserId);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    sAlbumId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sAlBumName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    sDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.sAlbumId);
                    table.ForeignKey(
                        name: "FK_Album_User",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Follow",
                columns: table => new
                {
                    FollowerId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sFolloweeId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow", x => new { x.FollowerId, x.sFolloweeId });
                    table.ForeignKey(
                        name: "FK_Follow_Followee_User",
                        column: x => x.FollowerId,
                        principalTable: "User",
                        principalColumn: "sUserId");
                    table.ForeignKey(
                        name: "FK_Follow_Follower_User",
                        column: x => x.sFolloweeId,
                        principalTable: "User",
                        principalColumn: "sUserId");
                });

            migrationBuilder.CreateTable(
                name: "PlayList",
                columns: table => new
                {
                    sPlayListId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sPlayListName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    sDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    bIsPrivate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayList", x => x.sPlayListId);
                    table.ForeignKey(
                        name: "FK_Playlist_User",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Album_AlbumGenre",
                columns: table => new
                {
                    sAlbumId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sAlbumGenreId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album_AlbumGenre", x => new { x.sAlbumId, x.sAlbumGenreId });
                    table.ForeignKey(
                        name: "FK_Album_AlbumGenre_Album",
                        column: x => x.sAlbumId,
                        principalTable: "Album",
                        principalColumn: "sAlbumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Album_AlbumGenre_AlbumGenre",
                        column: x => x.sAlbumGenreId,
                        principalTable: "AlbumGenre",
                        principalColumn: "sAlbumGenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    sTrackId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    sDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sthumbnail = table.Column<string>(type: "varchar(100)", nullable: false),
                    sSource = table.Column<string>(type: "varchar(30)", nullable: false),
                    sHashtag = table.Column<string>(type: "varchar(100)", nullable: true),
                    bIsPrivate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sAlbumId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackGenreId = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.sTrackId);
                    table.ForeignKey(
                        name: "FK_Track_Album",
                        column: x => x.sAlbumId,
                        principalTable: "Album",
                        principalColumn: "sAlbumId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Track_TrackGenre",
                        column: x => x.sTrackGenreId,
                        principalTable: "TrackGenre",
                        principalColumn: "sTrackGenreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Track_User",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    sCommentId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sContent = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.sCommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Track",
                        column: x => x.sTrackId,
                        principalTable: "Track",
                        principalColumn: "sTrackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_User",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    sHistoryId = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.sHistoryId);
                    table.ForeignKey(
                        name: "FK_History_Track",
                        column: x => x.sTrackId,
                        principalTable: "Track",
                        principalColumn: "sTrackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_History_User",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    sUserId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => new { x.sUserId, x.sTrackId });
                    table.ForeignKey(
                        name: "FK_Like_Track",
                        column: x => x.sTrackId,
                        principalTable: "Track",
                        principalColumn: "sTrackId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Like_User",
                        column: x => x.sUserId,
                        principalTable: "User",
                        principalColumn: "sUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayList_Track",
                columns: table => new
                {
                    sPlaylistId = table.Column<string>(type: "varchar(50)", nullable: false),
                    sTrackId = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist_Track", x => new { x.sPlaylistId, x.sTrackId });
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_Playlist",
                        column: x => x.sPlaylistId,
                        principalTable: "PlayList",
                        principalColumn: "sPlayListId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_Track",
                        column: x => x.sTrackId,
                        principalTable: "Track",
                        principalColumn: "sTrackId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_sUserId",
                table: "Album",
                column: "sUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_AlbumGenre_sAlbumGenreId",
                table: "Album_AlbumGenre",
                column: "sAlbumGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_sTrackId",
                table: "Comment",
                column: "sTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_sUserId",
                table: "Comment",
                column: "sUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_sFolloweeId",
                table: "Follow",
                column: "sFolloweeId");

            migrationBuilder.CreateIndex(
                name: "IX_History_sTrackId",
                table: "History",
                column: "sTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_History_sUserId",
                table: "History",
                column: "sUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_sTrackId",
                table: "Like",
                column: "sTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayList_sUserId",
                table: "PlayList",
                column: "sUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayList_Track_sTrackId",
                table: "PlayList_Track",
                column: "sTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_sAlbumId",
                table: "Track",
                column: "sAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Track_sTrackGenreId",
                table: "Track",
                column: "sTrackGenreId",
                unique: true,
                filter: "[sTrackGenreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Track_sUserId",
                table: "Track",
                column: "sUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Album_AlbumGenre");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Follow");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "PlayList_Track");

            migrationBuilder.DropTable(
                name: "AlbumGenre");

            migrationBuilder.DropTable(
                name: "PlayList");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "TrackGenre");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
