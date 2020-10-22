using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    class LikeService
    {
        private readonly Guid _userID;

        public LikeService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    PostID = model.PostID,
                    LikedPost = model.LikedPost,
                    Liker = model.Liker,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<LikeListItem> GetList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Likes
                    .Select(
                        e =>
                        new LikeListItem
                        {
                            Liker = e.Liker,
                            User = e.User,
                        }
                        );
                return query.ToArray();
            }
        }

        public LikeDetail GetLikeByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Likes
                    .Single(e => e.PostID == id);
                return
                    new LikeDetail
                    {
                        LikedPost = entity.LikedPost,
                    };
            }
        }

        public bool DeleteLike(int PostID)
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



