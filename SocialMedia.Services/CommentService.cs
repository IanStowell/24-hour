using SocialMedia.Models;
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class CommentService
    {
        private readonly Guid _userID;

        public CommentService(Guid userId)
        {
            _userID = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    PostID = model.PostID,
                    Text = model.Text,
                    //Do we need to put the ID in here????
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            CommentPost = e.CommentPost,
                            Text = e.Text,
                            CommentID = e.CommentID
                        }
                        );
                return query.ToArray();
            }
        }

        public CommentDetail GetACommentByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Comments
                    .Single(e => e.CommentID == id);
                return
                    new CommentDetail
                    {
                        Author = entity.Author,
                        CommentID = entity.CommentID,
                        Text = entity.Text,
                    };
            }
        }

        public bool DeleteComment(int CommentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Comments
                    .Single(e => e.CommentID == CommentID);

                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}


