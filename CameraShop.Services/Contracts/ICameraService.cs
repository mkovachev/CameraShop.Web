using CameraShop.Data.Enums;
using CameraShop.Services.ServiceModels;
using System.Collections.Generic;

namespace CameraShop.Services.Contracts
{
    public interface ICameraService
    {
        IEnumerable<CameraServiceModel> GetAll();

        void Add(Make make, string model, double price, int quantity, int MinShutterSpeed, int MaxShutterSpeed, MinISO MinISO, int MaxISO, bool IsFullFrame, ImageURL imageURL);

        void Delete();
    }
}
