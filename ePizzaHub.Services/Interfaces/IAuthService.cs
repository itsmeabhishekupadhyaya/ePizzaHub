using ePizzaHub.Core.Entities;
using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;


namespace ePizzaHub.Services.Interfaces
{
    public interface IAuthService : IService<User>
    {
        UserModel ValidateUser(string Email, string Password);

        bool Create(User user, string Roles);
    }
}
