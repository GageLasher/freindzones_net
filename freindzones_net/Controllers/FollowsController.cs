using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using freindzones_net.Models;
using freindzones_net.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace freindzones_net.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class FollowsController : ControllerBase
    {
        private readonly FollowsService _fs;

        public FollowsController(FollowsService fs)
        {
            _fs = fs;
        }
        [HttpPost]
        public async Task<ActionResult<Follow>> Create([FromBody] Follow data)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                data.Follower = user.Id;
                Follow created = _fs.Create(data);
                return Ok(created);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Remove(int id)
        {
            try
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();

                _fs.Remove(id, user.Id);
                return Ok("delete");
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}