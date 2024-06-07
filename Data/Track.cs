

namespace stone_music_backend.Data
{
    public class Track
    {
        public string TrackId { get; set; }

        public string TrackName { get; set; }

        public string? Description { get; set; }

        public string Thumbnail { get; set; }

        public string Source { get; set; }

        public string? Hashtag { get; set; }

        public bool IsPrivate { get; set; }

        public DateTime CreatedAt { get; set; }


        // reference property
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public string? TrackGenreId { get; set; }
        public virtual TrackGenre? TrackGenre { get; set; }


        // collection property

        public virtual ICollection<Like>? Likes { get; set; }

        public virtual ICollection<History>? Histories { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }


        public virtual ICollection<PlayList_Track> PlayList_Tracks { get; set; }

    }
}