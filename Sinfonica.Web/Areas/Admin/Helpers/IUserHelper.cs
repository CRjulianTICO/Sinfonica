using Microsoft.AspNetCore.Identity;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using Sinfonica.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Helpers
{
    public interface IUserHelper
    {
        Task<Sinfonica.Web.Areas.Admin.Data.Entities.User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string password);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user);

        Task<IdentityResult> ChangePasswordAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string oldPassword, string newPassword);

        Task<SignInResult> ValidatePasswordAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string roleName);

        Task<bool> IsUserInRoleAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string roleName);



        Task<string> GenerateEmailConfirmationTokenAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user);

        Task<IdentityResult> ConfirmEmailAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string token);

        Task<Sinfonica.Web.Areas.Admin.Data.Entities.User> GetUserByIdAsync(string userId);

        Task<string> GeneratePasswordResetTokenAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user);

        Task<IdentityResult> ResetPasswordAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string token, string password);


    }
}
