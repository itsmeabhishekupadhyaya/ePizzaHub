using ePizzaHub.Core.Entities;
using ePizzaHub.Models;


namespace ePizzaHub.Repositories.Interfaces
{
    public interface IUserRespository: IRepository<User>
    {
        UserModel ValidateUser(string Email, string Password);

        bool Create(User user, string Roles);
    }
}
