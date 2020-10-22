using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ReplyService
    {
            private readonly Guid _userID;
            public ReplyService(Guid userID)
            {
                _userID = userID;
            }
            public bool CreatePost(ReplyCreate model)
            {
                var entity =
                    new Reply()
                    {
                        PostID = model.PostID,
                        Text = model.Text,
                        //No user ID
                    
                    };
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Replies.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }

            public IEnumerable<ReplyListItem> GetList()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                        .Replies
                        .Select(
                            e =>
                            new ReplyListItem
                            {
                                Text = e.Text,
                            
                                //PostID, OwnerID, CommentID and Comment Post are not being used

                            }
                            );
                    return query.ToArray();
                }
            }

            public ReplyDetail GetPostByID(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx.Replies
                        .Single(e => e.PostID == id);  // not sure which ID to use
                    return
                        new ReplyDetail
                        {
                            Author = entity.Author,
                            ID = entity.PostID, // what ID
                            Text = entity.Text,
                        };
                }
            }

            public bool DeleteReply(int PostID)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                ctx.Replies
                .Single(e => e.PostID == PostID);
                    ctx.Replies.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
            }





        }
}
