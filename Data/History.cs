using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class History
    {
        public string HistoryId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // reference property

        public string UserId { get; set; }
        public virtual User User { get; set; }


        public string TrackId { get; set; }
        public virtual Track Track { get; set; }


    }
}