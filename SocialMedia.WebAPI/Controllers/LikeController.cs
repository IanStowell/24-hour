using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//namespace SocialMedia.WebAPI.Controllers
//{
//   [ Authorize]
//    public class LikeController : ApiController
//    {
//        public LikeService CreateLikeService()
//        {
//            var userID = Guid.Parse(User.Identity());
//            var userService = new LikeService(userID);
//            return userService;
//        }
//        [HttpGet]
//        public IHttpActionResult Get(string id)
//        {
//            LikeService likeService = CreateLikeService();
//            var user = likeService.GetLikes(id);
//            return Ok(user);
//        }
//        [HttpGet]
//        public IHttpActionResult Get(int id)
//        {
//            CreateLikeService likeService = CreateLikeService();
//            var user = likeService.GetLikesByPost(id);
//            return Ok(user);
//        }
//        public IHttpActionResult Post(LikeCreate like)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var service = CreateLikeService();

//            if (!service.CreateLike(like))
//                return InternalServerError();

//            return Ok();
//        }
//        public IHttpActionResult Put(LikeEdit like)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);

//            var service = CreateLikeService();

//            if (!service.UpdateLike(like)) return InternalServerError();

//            return Ok();
//        }
//        public IHttpActionResult Delete(string id)
//        {
//            var service = CreateLikeService();

//            if (!service.DeleteLike(id)) return InternalServerError();

//            return Ok();
//        }
//    }
//}
