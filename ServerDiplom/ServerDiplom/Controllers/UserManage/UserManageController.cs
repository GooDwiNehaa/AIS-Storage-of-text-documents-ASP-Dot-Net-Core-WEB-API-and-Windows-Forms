using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerDiplom.BusinessLogic;
using ServerDiplom.Controllers.Auth.Data;
using ServerDiplom.Models;

namespace ServerDiplom.Controllers.UserManage
{
    [ApiController]
    public class UserManageController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public UserManageController(ApplicationContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [Route("get-all-users")]
        [HttpGet]
        public async Task<List<UserData>> GetAllUsers()
        {
            var users = await _db.Users
                .Select(u => new UserData
                {
                    UserType = u.TypeUser.Name,
                    Login = u.UserLogin
                })
                .ToListAsync();

            return users;
        }

        [Route("get-user-types")]
        [HttpGet]
        public async Task<List<string>> GetUserTypes()
        {
            var userTypes = await _db.TypeUsers
                .Select(tu => tu.Name)
                .ToListAsync();

            return userTypes;
        }

        [Route("add-user")]
        [HttpPost]
        public async Task<int> AddUser([FromBody] UserData userData)
        {
            var loginExist = _db.Users
                .Select(u => u.UserLogin)
                .Contains(userData.Login);

            if (!loginExist)
            {
                var userType = await _db.TypeUsers.FirstOrDefaultAsync(tu => tu.Name == userData.UserType);

                User user = new User
                {
                    UserLogin = userData.Login,
                    UserPassword = HashData.GetHash(userData.Password),
                    TypeUser = userType
                };

                _db.Users.Add(user);

                await _db.SaveChangesAsync();

                return 0;
            }
            else
            {
                return 1;
            }
        }

        [Route("del-user/{login}")]
        [HttpDelete]
        public async Task DelUser([FromRoute] string login)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserLogin == login);

            _db.Users.Remove(user);

            await _db.SaveChangesAsync();
        }

        [Route("edit-user")]
        [HttpPut]
        public async Task<int> EditUser([FromBody] UserData userData) 
        {
            var loginExist = _db.Users
                .Select(u => u.UserLogin)
                .Contains(userData.Login);

            if (!loginExist)
            {
                var userType = await _db.TypeUsers.FirstOrDefaultAsync(tu => tu.Name == userData.UserType);

                var user = await _db.Users.FirstOrDefaultAsync(u => u.UserLogin == userData.OldLogin);

                user.UserLogin = userData.Login;
                user.UserPassword = userData.Password;
                user.TypeUser = userType;

                await _db.SaveChangesAsync();

                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
