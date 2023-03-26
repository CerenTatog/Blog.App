using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.Models
{
    public class FollowUsers : Base
    {
        public int UserId { get; set; }
        public int FollowUserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
