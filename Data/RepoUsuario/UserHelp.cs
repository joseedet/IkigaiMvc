using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ikigai.Data.Interface;
using Microsoft.AspNetCore.Identity;

namespace Ikigai.Data.RepoUsuario
{
    public class UserHelp : IUserHelp
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly SignInManager<IdentityUser> _signInManager;

        public UserHelp(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager
           )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

        }


        public async Task<IdentityResult> AddUserAsync(IdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user,password);
            
        }

        public async Task AddUserToRoleAsync(IdentityUser user, string roleName)
        {
             await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<bool> DeleteUserAsync(string email)
        {
           var user = await GetUserByEmailAsync(email);
            if (user == null)
            {
                return true;
            }

            var response = await _userManager.DeleteAsync(user);
            return response.Succeeded;
        }

        public async Task<IdentityUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUserInRoleAsync(IdentityUser user, string roleName)
        {
              return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(IdentityUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public Task<SignInResult> ValidatePasswordAsync(IdentityUser user, string password)
        {
            throw new NotImplementedException();
        }
    }
}