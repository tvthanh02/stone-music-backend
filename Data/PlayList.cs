using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class PlayList
    {
        public string PlayListId { get; set; }

        public string PlayListName { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsPrivate { get; set; }

        //reference property 

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string PlayListGenreId { get; set; }
        public virtual PlayListGenre PlayListGenre { get; set; }

        //collection property

        public virtual ICollection<PlayList_Track> PlayList_Tracks { get; set; }




    }
}