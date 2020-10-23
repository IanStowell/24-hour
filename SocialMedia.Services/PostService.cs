using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class PostService
    {
        private readonly Guid _userID;

        public PostService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    Text = model.Text,
                    Title = model.Title,
                    UserID = model.UserID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Select(
                        e =>
                        new PostListItem
                        {
                            Author = e.Author,
                            ID = e.ID,
                            Title = e.Title,
                        }
                        );
                return query.ToArray();
            }
        }

        public PostDetail GetPostByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Posts
                    .Single(e => e.ID == id);
                return
                    new PostDetail
                    {
                        Author = entity.Author,
                        ID = entity.ID,
                        Text = entity.Text,
                        Title = entity.Title,
                    };
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single(e => e.CommentID == model.PostId);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int PostID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
            ctx.Likes
            .Single(e => e.PostID == PostID);
                ctx.Likes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }




    }
}