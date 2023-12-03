# Project Roadmap 
## Further Exploration with Authentication

## Getting Started...
1. Once you have completed the API build process as outlined in the [Project Roadmap and Notes](https://github.com/RyanDuff613/API.Solution/blob/main/Notes.md) and [API Documentation](https://github.com/RyanDuff613/API.Solution/blob/main/ApiDocumentationExample.md) on the main branch of this repository, we can proceed to explore authentication on the second branch named `Authentiation`.
    - `$ git checkout Authentiation`
2. Modify the `appsettings.json` file with the following code. This file includes database connection details and other configurations required for JWT authentication.
    <details><summary><code>ParksApi/appsettings.json</code></summary> 

    ```c#
  {
    "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
      }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=parks_api;uid=root;pwd=epicodus;",
      
      "ConnStr": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JWTAuthDB;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
      },
      
    "JWT": {
      "ValidAudience": "http://localhost:4200",
      "ValidIssuer": "http://localhost:5000",
      "Secret": "JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr"
      }
  }
    ```
    </details>
3. Create a new folder, `Auth` and create the `ApplicationDbContext` class under Auth folder using the following Git commands and add below code. We will add all the classes related to authentication under the Auth folder in the next following steps. 
    -`$ cd ParksApi`
    -`$ git mkdir Auth`
    -`$ cd Auth`
<details><summary><code>ParksApi/ApplicationDbContext.cs</code></summary> 

    ```c#
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ParksApi.Auth
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
    ```
</details>

4. Create file `UserRoles.cs` in the `Auth` folder using the following Git command and add the code below.
    -`$ git touch UserRoles.cs`
<details><summary><code>Auth/UserRoles.cs</code></summary> 

    ```c#
namespace ParksApi.Auth
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
    ```
</details>   

5. Create file `RegisterModel.cs ` in the `Auth` folder using the following Git command and add the code below.
     -`$ git touch RegisterModel.cs`
<details><summary><code>Auth/RegisterModel.cs</code></summary> 

    ```c#
using System.ComponentModel.DataAnnotations;

namespace ParksApi.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
    ```
</details>

6. Create file `LoginModel.cs` in the `Auth` folder using the following Git command and add the code below.
    -`$ touch LoginModel.cs`
<details><summary><code>Auth/LoginModel.cs</code></summary> 

    ```c#
using System.ComponentModel.DataAnnotations;

namespace ParksApi.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
    ```
</details>

7. Create file `Response.cs` in the `Auth` folder using the following Git command and add the code below.
    -`$ touch Response.cs`
<details><summary><code>Auth/Response.cs</code></summary> 

    ```c#
namespace ParksApi.Auth
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
    ```
</details>

8. Create controller file `AuthenticateController` inside the `Controllers` folder using the following Git commands and add below code. 
    -`$ cd ..`
    -`$ cd Controllers`
    -`$ touch AuthenticateController`
<details><summary><code>Controllers/AuthenticateController.cs</code></summary> 

    ```c#
using JWTAuthentication.NET6._0; 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ParksApi.Auth; 
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace JWTAuthentication.NET6._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

               var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
    ```
</details>

10. In the production directory `ParksApi`, add the following packages using the Git commands:
    -`$ cd ..`
    -`$ dotnet add package Microsoft.AspNetCore.Identity.UI --version 5.0.14`
    -`$ dotnet add package Microsoft.AspNetCore.Identity.UI --version 5.0.14`

11. Add a migration and update the each individual context files by doing the Git commands:
    -`$ dotnet ef migrations add InitialCreate -c ParksApiContext`
    -`$ dotnet ef database update -c ParksApiContext`
    -`$ dotnet ef migrations add AuthInitialCreate -c ApplicationDbContext`
    -`$ dotnet ef database update -c ApplicationDbContext`

12. View the Parks API with Authentication in swagger by doing the Git command:
    -`$ dotnet watch run`