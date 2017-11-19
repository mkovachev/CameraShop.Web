using CameraShop.Data.Enums;
using CameraShop.Services.ServiceModels;
using System.Collections.Generic;

namespace CameraShop.Services.Contracts
{
    public interface ICameraService
    {
        IEnumerable<CameraServiceModel> GetAll();

        CameraExtendedServiceModel GetCameraById(string id);

        void Add(
            Make make,
            string model,
            double price,
            int quantity,
            int minShutterSpeed,
            int maxShutterSpeed,
            MinISO minISO,
            int maxISO,
            bool isFullFrame,
            string videoResolution,
            IEnumerable<LightMetering> lightMeterings,
            string description,
            string imageURL,
            string userId);

        void Edit(string id, Make make, string model, double price, int quantity, int minShutterSpeed, int maxShutterSpeed, MinISO minISO, int maxISO, bool isFullFrame, string videoResolution, IEnumerable<LightMetering> lightMeterings, string description, string imageURL, string userId);

        void Delete(string id);

        

    }
}
