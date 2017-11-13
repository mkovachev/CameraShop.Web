using CameraShop.Data;
using CameraShop.Services.Contracts;
using CameraShop.Services.ServiceModels;
using System.Collections.Generic;
using System.Linq;

namespace CameraShop.Services.Services
{
    public class CameraService : ICameraService
    {
        private readonly CameraShopDbContext db;

        public CameraService(CameraShopDbContext db) => this.db = db;

        public IEnumerable<CameraServiceModel> GetAll()
            => this.db.Cameras
                .OrderBy(c => c.Id)
                .Select(c => new CameraServiceModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    ImageURL = c.ImageURL
                })
                .ToList();
    }
}
