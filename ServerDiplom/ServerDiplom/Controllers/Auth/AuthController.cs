using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerDiplom.Models;
using ServerDiplom.Controllers.Auth.Data;
using ServerDiplom.BusinessLogic;

namespace ServerDiplom.Controllers.Auth
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public AuthController(ApplicationContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [Route("login")]
        [HttpPost]
        public async Task<int> Login([FromBody] UserData data)
        {
            var user = await _db.Users
                .Include(tu => tu.TypeUser)
                .FirstOrDefaultAsync(x => x.UserLogin == data.Login && x.UserPassword == HashData.GetHash(data.Password));

            if (user != null)
            {
                return user.TypeUser.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}
