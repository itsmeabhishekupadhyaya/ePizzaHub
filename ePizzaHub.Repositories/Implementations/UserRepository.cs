using ePizzaHub.Core;
using ePizzaHub.Core.Entities;
using ePizzaHub.Models;
using ePizzaHub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzaHub.Repositories.Implementations
{
    public class UserRepository : Respository<User>, IUserRespository
    {
        public UserRepository(AppDbContext db) : base(db)
        {

        }

        public bool Create(User user, string Role)
        {
            try
            {
                Role role = _db.Roles.Where(r => r.Name == Role).FirstOrDefault();
                if (role != null)
                {
                    user.Roles.Add(role);
                    user.Password=BCrypt.Net.BCrypt.HashPassword(user.Password);
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    return true;

                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return false;
          

        }

        public UserModel ValidateUser(string Email, string Password)
        {
            User user = _db.Users.Include(user => user.Roles).Where(u => u.Email == Email).FirstOrDefault();
            if (user != null)
            {
                bool isVerify = BCrypt.Net.BCrypt.Verify(Password,user.Password);
                if (isVerify)
                {
                    UserModel model = new UserModel
                    {
                        Id = user.Id,
                        Name   = user.Name,
                        Email = user.Email,
                        PhoneNumber= user.PhoneNumber,
                        Roles=user.Roles.Select(r => r.Name).ToArray(),

                    };
                    return model;
                }

            }
            return null;
        }
    }
}
