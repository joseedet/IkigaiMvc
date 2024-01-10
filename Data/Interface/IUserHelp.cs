using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ikigai.Data.Interface
{
    public interface IUserHelp
    {
        Task <IdentityUser>  GetUserByEmailAsync(string  email);

        Task<IdentityResult> AddUserAsync(IdentityUser user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(IdentityUser user, string roleName);

        Task<bool> IsUserInRoleAsync(IdentityUser user, string roleName);

        //Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<bool> DeleteUserAsync(string email);
        Task<IdentityResult> UpdateUserAsync(IdentityUser user);

        Task<SignInResult> ValidatePasswordAsync(IdentityUser user, string password);
    }
}