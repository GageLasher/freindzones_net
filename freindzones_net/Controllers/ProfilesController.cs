using System.Collections.Generic;
using freindzones_net.Models;
using freindzones_net.Services;
using Microsoft.AspNetCore.Mvc;

namespace freindzones_net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _ps;

        public ProfilesController(ProfilesService ps)
        {
            this._ps = ps;
        }
        [HttpGet]
        public ActionResult<List<Profile>> GetAll()
        {
            try
            {
                List<Profile> profiles = _ps.GetAll();
                return Ok(profiles);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Profile> GetById(string id)
        {
            try
            {
                Profile profile = _ps.GetById(id);
                return Ok(profile);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}/following")]
        public ActionResult<List<ProfileFollow>> GetProfileFollowing(string id)
        {
            try
            {
                List<ProfileFollow> followings = _ps.GetFollowing(id);
                return Ok(followings);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}