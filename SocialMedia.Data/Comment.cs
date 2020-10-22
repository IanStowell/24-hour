using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [Required]       
        public int PostID { get; set; }
        [ForeignKey(nameof(PostID))]
        public virtual Post CommentPost { get; set; }
        public string Text { get; set; } // JH added
        public Guid OwnerID { get; set; } // JH added
        public virtual User Author { get; set; } // JH added
    }
}
