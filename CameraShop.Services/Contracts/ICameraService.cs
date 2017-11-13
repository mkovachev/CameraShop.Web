using CameraShop.Services.ServiceModels;
using System.Collections.Generic;

namespace CameraShop.Services.Contracts
{
    public interface ICameraService
    {
        IEnumerable<CameraServiceModel> GetAll();
    }
}
