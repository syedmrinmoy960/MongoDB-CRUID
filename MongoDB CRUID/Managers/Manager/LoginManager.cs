using Microsoft.IdentityModel.Tokens;
using MongoDB_CRUID.Managers.IManager;
using MongoDB_CRUID.Models;
using MongoDB_CRUID.Repositories.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MongoDB_CRUID.Managers.Manager
{
    public class LoginManager : ILoginManager
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;

        public LoginManager(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
        }
        public async Task<string> AuthenticateAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Email or password is null.");
                throw new ArgumentNullException("Email and password must be provided.");
            }

            Console.WriteLine($"Attempting to authenticate user with email: {email}");

            var user = await _loginRepository.GetUserByEmailAsync(email);

            if (user == null && !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null;
            }

            var token = GenerateJwtToken(user);
            return token;
        }


        /*  public async Task<string> AuthenticateAsync(string email, string password)
          {
              if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
              {
                  Console.WriteLine("Email or password is null.");
                  throw new ArgumentNullException("Email and password must be provided.");
              }

              Console.WriteLine($"Attempting to authenticate user with email: {email}");

              // Retrieve the user by email
              var user = await _loginRepository.GetUserByEmailAsync(email);

              // Check if the user exists
              if (user == null)
              {
                  Console.WriteLine("User not found.");
                  return null; // User not found
              }

              Console.WriteLine($"Retrieved hashed password from database: {user.Password}");

              bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
              if (!isPasswordValid)
              {
                  Console.WriteLine("Invalid password.");
                  return null; // Invalid password
              }

              // Generate JWT token for the authenticated user
              var token = GenerateJwtToken(user);
              return token;
          }*/
        /* private string GenerateJwtToken(Users user)
         {
             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new[]
                 {
                     new Claim(ClaimTypes.Name, user.UserName),
                     new Claim(ClaimTypes.Email, user.Email)
                 }),
                 Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpireMinutes"])),
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
             };

             var token = tokenHandler.CreateToken(tokenDescriptor);
             return tokenHandler.WriteToken(token);
         }*/

        private string GenerateJwtToken(adminusers user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
        }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpireMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
