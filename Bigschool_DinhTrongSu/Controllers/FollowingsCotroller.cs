using Bigschool_DinhTrongSu.DTOs;
using Bigschool_DinhTrongSu.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Bigschool_DinhTrongSu.Controllers
{
    public class FollowingsCotroller : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public FollowingsCotroller()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FollowerId == followingDto.FolloweeId))
                return BadRequest("Following already exists");
            var folowing = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            _dbContext.Followings.Add(folowing);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}