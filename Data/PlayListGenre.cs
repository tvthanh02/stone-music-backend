using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class PlayListGenre
    {
        public string PlayListGenreId { get; set; }

        public string PlayListGenreName { get; set; }

        public virtual ICollection<PlayList> PlayLists { get; set; }
    }
}