using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class Follow
    {
        public string FollowerId { get; set; }

        public string FolloweeId { get; set; }

        public virtual User Follower { get; set; }

        public virtual User Followee { get; set; }
    }
}