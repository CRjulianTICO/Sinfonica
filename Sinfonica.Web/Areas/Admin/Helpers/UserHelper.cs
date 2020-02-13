using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using Sinfonica.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<Sinfonica.Web.Areas.Admin.Data.Entities.User> userManager;
        private readonly SignInManager<Sinfonica.Web.Areas.Admin.Data.Entities.User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserHelper(UserManager<Sinfonica.Web.Areas.Admin.Data.Entities.User> userManager, SignInManager<Sinfonica.Web.Areas.Admin.Data.Entities.User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }



        public async Task<IdentityResult> AddUserAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string password)
        {
            return await this.userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> ChangePasswordAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string oldPassword, string newPassword)
        {
            return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<Sinfonica.Web.Areas.Admin.Data.Entities.User> GetUserByEmailAsync(string email)
        {
            return await this.userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await this.signInManager.PasswordSignInAsync(
                                model.Username,
                                model.Password,
                                model.RememberMe,
                                false);
        }

        public async Task LogoutAsync()
        {
            await this.signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user)
        {
            return await this.userManager.UpdateAsync(user);
        }


        public async Task<SignInResult> ValidatePasswordAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string password)
        {

            return await this.signInManager.
                CheckPasswordSignInAsync
                (user, password, false);
        }




        //Metodos de Roles

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await this.roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task AddUserToRoleAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string roleName)
        {
            await this.userManager.AddToRoleAsync(user, roleName);
        }






        public async Task<bool> IsUserInRoleAsync(Sinfonica.Web.Areas.Admin.Data.Entities.User user, string roleName)
        {
            return await this.userManager.IsInRoleAsync(user, roleName);
        }







        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await this.userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await this.userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await this.userManager.FindByIdAsync(userId);
        }






        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return await this.userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string password)
        {
            return await this.userManager.ResetPasswordAsync(user, token, password);
        }




    }
}
