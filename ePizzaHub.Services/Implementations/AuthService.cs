using ePizzaHub.Core.Entities;
using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Services.Implementations
{
    public class AuthService : Service<User>, IAuthService
    {
        IUserRespository _userrepo;
        public AuthService(IUserRespository userrepo): base(userrepo) 
        {
            _userrepo = userrepo;
            
        }
        public bool Create(User user, string Roles)
        {
          return  _userrepo.Create(user, Roles);
        }

        public UserModel ValidateUser(string Email, string Password)
        {
            return _userrepo.ValidateUser(Email, Password);
        }
    }
}
