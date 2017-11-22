using CameraShop.Services.ServiceModels;
using System.Collections.Generic;

namespace CameraShop.Services.Contracts
{
    public interface IUserService
    {
        UserServiceModel GetUserProfile(string email);

        IEnumerable<UserServiceModel> GetUserSWithRoles();

        void Create(string id, string username, string email);

    }
}
