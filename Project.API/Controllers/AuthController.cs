using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.API.Resources;
using Project.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Antiforgery;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
        
    {
        private readonly IConfiguration configuration;
        private readonly IPasswordHasher<IdentityUser> hasher;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ILogger<AuthController> logger;

        public AuthController(IConfiguration configuration, IPasswordHasher<IdentityUser> hasher, UserManager<IdentityUser> userManager, ILogger<AuthController> logger) {
            this.configuration = configuration;
            this.hasher = hasher;
            this.userManager = userManager;
            this.logger = logger;
        }

        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateJwtToken([FromBody]LoginResource identityResource) {
            try {
                var jwtsvc = new JWTServices<IdentityUser>(configuration, logger, userManager, hasher);
                var token = await jwtsvc.GenerateJwtToken(identityResource);
                return Ok(token);

            } catch (Exception exc) {
                logger.LogError($"Exception thrown when creating JWT: {exc}");  
            }

            return BadRequest("Failed to generate JWT token");
        }

    }
}