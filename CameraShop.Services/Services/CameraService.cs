using CameraShop.Data;
using CameraShop.Services.Contracts;
using CameraShop.Services.ServiceModels;
using System.Collections.Generic;
using System.Linq;
using CameraShop.Data.Enums;
using CameraShop.Data.Models;

namespace CameraShop.Services.Services
{
    public class CameraService : ICameraService
    {
        private readonly CameraShopDbContext db;

        public CameraService(CameraShopDbContext db) => this.db = db;

        public void Add(Make make, string model, double price, int quantity, int minShutterSpeed, int maxShutterSpeed, MinISO minISO, int maxISO, bool isFullFrame, ImageURL imageURL)
        {
            var camera = new Camera
            {
                Make = make,
                Model = model,
                Price = price,
                Quantity = quantity,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                MinISO = minISO,
                MaxISO = maxISO,
                IsFullFrame = isFullFrame,
                ImageURL = imageURL
            };

            this.db.Add(camera);
            this.db.SaveChanges();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

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
