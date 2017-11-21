using CameraShop.Services.ServiceModels;
using System.Collections.Generic;

namespace CameraShop.Services.Contracts
{
    public interface IUserService
    {
        UserServiceModel GetUserProfile(string id);

        IEnumerable<UserServiceModel> GetUserSWithRoles();

    }
}
