using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class LikeCreate
    {
        [Required]
        public string Name;
        [Required]
        public int PostID;
        public virtual Post LikedPost { get; set; }
        public virtual User Liker { get; set; }
    }
}
