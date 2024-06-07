using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class User
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string Password { get; set; }

        public string? Email { get; set; }

        public string? Avatar { get; set; }

        public string? Bio { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Account { get; set; }

        // collection property

        public virtual ICollection<Album>? Albums { get; set; }

        public virtual ICollection<Track>? Tracks { get; set; }

        public virtual ICollection<PlayList>? PlayLists { get; set; }

        public virtual ICollection<Like>? Likes { get; set; }

        public virtual ICollection<History>? Histories { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

        public virtual ICollection<Follow>? Followers { get; set; }

        public virtual ICollection<Follow>? Followees { get; set; }


    }
}