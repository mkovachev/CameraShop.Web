using CameraShop.Services.ServiceModels;

namespace CameraShop.Services.Contracts
{
    public interface IUserService
    {
        UserServiceModel GetUserProfile(string id);
    }
}
