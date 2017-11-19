using CameraShop.Data;
using CameraShop.Services.Contracts;
using CameraShop.Services.ServiceModels;
using System.Linq;

namespace CameraShop.Services.Services
{
    public class UserService : IUserService
    {
        private readonly CameraShopDbContext db;

        public UserService(CameraShopDbContext db) => this.db = db;

      public UserServiceModel GetUserProfile(string id)
          => this.db.Users
                      .Where(u => u.Id == id)
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
    }
}
