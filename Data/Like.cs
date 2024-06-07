using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class Like
    {
        public string UserId { get; set; }

        public string TrackId { get; set; }

        // reference property


        public virtual User User { get; set; }

        public virtual Track Track { get; set; }
    }
}