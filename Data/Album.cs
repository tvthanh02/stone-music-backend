using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class Album
    {
        public string AlbumId { get; set; }

        public string AlbumName { get; set; }

        public string? Description { get; set; }

        public DateTime CreateAt { get; set; }


        // reference property

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string AlbumGenreId { get; set; }
        public virtual AlbumGenre AlbumGenre { get; set; }

        // collection property
        public virtual ICollection<Track> Tracks { get; set; }



    }
}