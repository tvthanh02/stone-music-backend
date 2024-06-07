using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class AlbumGenre
    {
        public string AlbumGenreId { get; set; }

        public string AlbumGenreName { get; set; }

        // collection property 

        public virtual ICollection<Album_AlbumGenre> Album_AlbumGenres { get; set; }

    }
}