using ChatMeeting.API;
using ChatMeeting.Core.Domain;
using ChatMeeting.Core.Domain.Interfaces.Repositories;
using ChatMeeting.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChatMeeting.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ChatDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ChatDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();  
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Błąd przy dodawaniu użytownika: {user.UserName}");
                throw;
            }
        }

        public async Task<User?> GetUserById(Guid id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    _logger.LogWarning($"Nie znaleziono użytkownika");
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Błąd przy znajdowaniu użytownika i ID: {id}");
                throw;
            }
        }

        public async Task<User?> GetUserByLogin(string login)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u=>u.UserName == login);
                if (user == null)
                {
                    _logger.LogWarning($"Nie znaleziono użytkownika");
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Błąd przy znajdowaniu użytownika o loginie:{login}");
                throw;
            }
        }
    }
}
