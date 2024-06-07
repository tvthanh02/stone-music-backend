namespace stone_music_backend.Data
{
    public class TrackGenre
    {
        public string TrackGenreId { get; set; }

        public string TrackGenreName { get; set; }

        // reference property
        public virtual Track? Track { get; set; }
    }
}