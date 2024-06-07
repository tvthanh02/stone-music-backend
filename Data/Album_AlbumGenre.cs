namespace stone_music_backend.Data
{
    public class Album_AlbumGenre
    {
        public string AlbumId { get; set; }

        public string AlbumGenreId { get; set; }

        // reference property

        public virtual Album Album { get; set; }

        public virtual AlbumGenre AlbumGenre { get; set; }


    }
}