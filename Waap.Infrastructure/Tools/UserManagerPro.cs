
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Waap.Model.Entities.AppUser;

namespace Waap.Infrastructure.Tools
{
    public class UserManagerPro : UserManager<ApplicationUser>
    {
        public UserManagerPro(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

        }
        public async Task<ApplicationUser> FindByPhoneNumberAsync(string PhoneNumber)
        {
           
            var users = await Users.Where(u => u.PhoneNumber.Trim().ToLower() == PhoneNumber.Trim().ToLower()).FirstOrDefaultAsync();
            if (users == null) {
                return null;
            }
            return users;
        }

        public async Task<ApplicationUser> FindByUserNameOrEmailAsync(string userNameOrEmail)
        {
            var users = await Users.Where(u => u.UserName.ToLower() == userNameOrEmail.ToLower() || u.Email.ToLower() == userNameOrEmail.ToLower()).SingleOrDefaultAsync();

            if (users == null)
            {
                return null;
            }
            return users;
        }


        public async Task<bool> ExistByUserNameAsync(string userName)
        {
            return await Users.AnyAsync(u => u.UserName.ToLower() == userName.ToLower());
        }

        public async Task<bool> ExistByEmailAsync(string email)
        {
            return await Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<bool> IsDeletedUserAsync(string userName)
        {
            return await Users.IgnoreQueryFilters().AnyAsync(u => u.UserName.ToLower() == userName.ToLower() && u.IsDelete == true);
        }

        public async Task<bool> IsDeletedEmailAsync(string email)
        {
            return await Users.IgnoreQueryFilters().AnyAsync(u => u.Email.ToLower() == email.ToLower() && u.IsDelete == true);
        }
        public async Task<bool> IsDeletedPhoneNumberAsync(string phoneNumber)
        {
            return await Users.IgnoreQueryFilters().AnyAsync(u => u.PhoneNumber.ToLower() == phoneNumber.ToLower() && u.IsDelete == true);
        }
        public async Task<bool> ExistByPhoneNumberAsync(string phoneNumber)
        {
            return await Users.AnyAsync(u => u.PhoneNumber == phoneNumber);
        }

        public async Task<long> GetIdByUserName(string userName)
        {
            var user = await FindByNameAsync(userName);
            return user.Id;
        }
    }
}
