using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShouts.Entities
{
    public class FollowUser
    {
        [Key]
        public int FollowUserId { get; set; }
        public int FollowerApplicationUserId { get; set; }
        public int FollowingApplicationUserId { get; set; }
    }
}
