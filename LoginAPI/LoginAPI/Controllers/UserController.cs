using LoginAPI.Context;
using LoginAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDBcontext _authContext;

        public UserController(AppDBcontext appDBcontext)
        {
            _authContext = appDBcontext; 
        }

        [HttpPost("authentication")]   
        public async Task<IActionResult> Authenticate([FromBody] Users userObj)
        { 
            //if some one is sendig a blank object it will retur a bad request//
            if(userObj == null)
                return BadRequest();

            //If the user have the correct username and password as to the below logic, then the login will be success and return as
            //login success//
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.username == userObj.username && x.password == userObj.password);

            //If it is wrogn the it'll comes to this line and return the result
            if (user == null)
                return NotFound(new { Message = "User not found!"});
            
            return Ok(new 
            {
                Message = "Login Success!"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] Users userObj)
        {
            if (userObj == null)
                return BadRequest();

            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();  
            return Ok(new
            {
                Message = "User Registered!"
            });    
        }
    }
}
