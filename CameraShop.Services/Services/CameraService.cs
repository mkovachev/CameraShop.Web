using CameraShop.Data;
using CameraShop.Data.Enums;
using CameraShop.Data.Models;
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

        public void Add(Make make, string model, double price, int quantity, int minShutterSpeed, int maxShutterSpeed, MinISO minISO, int maxISO, bool isFullFrame, string videoResolution, IEnumerable<LightMetering> lightMeterings, string description, string imageURL, string userId)
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
                VideoResolution = videoResolution,
                LightMetering = (LightMetering)lightMeterings.Cast<int>().Sum(),
                Description = description,
                ImageURL = imageURL
            };

            this.db.Add(camera);
            this.db.SaveChanges();
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

        public void Edit(string id, Make make, string model, double price, int quantity, int minShutterSpeed, int maxShutterSpeed, MinISO minISO, int maxISO, bool isFullFrame, string videoResolution, IEnumerable<LightMetering> lightMeterings, string description, string imageURL, string userId)
        {
            var camera = this.db.Cameras.Find(id);

            if (camera == null)
            {
                return;
            }

            camera.Make = make;
            camera.Model = model;
            camera.Price = price;
            camera.Quantity = quantity;
            camera.MinShutterSpeed = minShutterSpeed;
            camera.MaxShutterSpeed = maxShutterSpeed;
            camera.MinISO = minISO;
            camera.MaxISO = maxISO;
            camera.IsFullFrame = isFullFrame;
            camera.VideoResolution = videoResolution;
            camera.LightMetering = (LightMetering)lightMeterings.Cast<int>().Sum();
            camera.Description = description;
            camera.ImageURL = imageURL;

            this.db.SaveChanges();

        }

        public void Delete(string id)
        {
            var camera = this.db.Cameras.Find(id);

            if (camera == null)
            {
                return;
            }

            this.db.Cameras.Remove(camera);
            this.db.SaveChanges();
        }
    }
}
