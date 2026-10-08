using CoursesDatabaseLibrary.Contexts;
using CoursesDatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursesDatabaseLibrary.Services
{
    public class UserService
    {
        private readonly CoursesContext _context = new();
        private readonly string _salt = "bv@sdwer1";

        private string GetPasswordHash(string password)
            => BCrypt.Net.BCrypt.HashPassword(_salt + password);

        private bool IsPasswordsEquals(string password, string passwordHash)
            => BCrypt.Net.BCrypt.Verify(_salt + password, passwordHash);

        public async Task<bool> RegisterUserAsync(string username, string email, string password, int roleId)
        {
            string passwordHash = GetPasswordHash(password);

            User user = new()
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                RoleId = roleId
            };

            if (_context.Users.FirstOrDefaultAsync(u => u.Username == username) is not null)
                return false;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> LoginUserAsync(string username, string password)
        {
            User? selectedUser = await _context.Users.FirstOrDefaultAsync(u=> u.Username == username);

            if (selectedUser is null)
                return false;

            return IsPasswordsEquals(password, selectedUser.PasswordHash);
        }
    }
}
