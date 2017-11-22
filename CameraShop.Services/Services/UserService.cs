using CameraShop.Data;
using CameraShop.Data.Models;
using CameraShop.Services.Contracts;
using CameraShop.Services.ServiceModels;
using System.Collections.Generic;
using System.Linq;

namespace CameraShop.Services.Services
{
    public class UserService : IUserService
    {
        private readonly CameraShopDbContext db;

        public UserService(CameraShopDbContext db)
        {
            this.db = db;
        }

        public void Create(string id, string userName, string email)
        {
            var user = this.db.Users.Find(id);

            if (user == null)
            {
                return;
            }

            user.Id = id;
            user.UserName = userName;
            user.Email = email;

            this.db.Add(user);
            this.db.SaveChanges();
        }

        public UserServiceModel GetUserProfile(string email)
            => this.db
                .Users
                .Where(u => u.Email == email)
                .Select(u => new UserServiceModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Cameras = u.Cameras.Select(c => new CameraServiceModel
                    {
                        Id = c.Id,
                        Make = c.Make,
                        Model = c.Model,
                        Price = c.Price,
                        Quantity = c.Quantity,
                        ImageURL = c.ImageURL
                    })

                })
                .FirstOrDefault();

        public IEnumerable<UserServiceModel> GetUserSWithRoles()
        {

            return this.db
                 .Users
                 .OrderBy(u => u.UserName)
                 .Select(u => new UserServiceModel
                 {
                     UserName = u.UserName,
                     Email = u.Email
                 })
                  .ToList();
        }
    }
}
