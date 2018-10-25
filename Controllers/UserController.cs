using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChattrApi.Data;
using ChattrApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChattrApi.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context, UserManager<User> user)
        {
            _userManager = user;
            _context = context;
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET api/values
        [HttpGet]
        public async Task<User> GetUser()
        {
            User currentUser = await GetCurrentUserAsync();
            return currentUser;
        }
    }
}
