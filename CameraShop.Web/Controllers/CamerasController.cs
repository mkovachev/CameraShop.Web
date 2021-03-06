﻿using CameraShop.Data.Models;
using CameraShop.Services.Contracts;
using CameraShop.Services.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CameraShop.Web.Controllers
{
    public class CamerasController : Controller
    {
        private readonly ICameraService cameras;
        private readonly UserManager<User> userManager;

        public CamerasController(ICameraService cameras, UserManager<User> userManager)
        {
            this.cameras = cameras;
            this.userManager = userManager;
        }

        public IActionResult All() => View(this.cameras.GetAll());

        public IActionResult Details(string id) => View(this.cameras.GetCameraById(id));

        [Authorize]
        public IActionResult Add() => View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(CameraExtendedServiceModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cameraModel);
            }

            this.cameras.Add(
                cameraModel.Make,
                cameraModel.Model,
                cameraModel.Price,
                cameraModel.Quantity,
                cameraModel.MinShutterSpeed,
                cameraModel.MaxShutterSpeed,
                cameraModel.MinISO,
                cameraModel.MaxISO,
                cameraModel.IsFullFrame,
                cameraModel.VideoResolution,
                cameraModel.LightMeterings,
                cameraModel.Description,
                cameraModel.ImageURL,
                this.userManager.GetUserId(User)
                );

            return RedirectToAction(nameof(HomeController.Index), "Home");

        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            var camera = this.cameras.GetCameraById(id);

            if (camera == null)
            {
                return NotFound();
            }

            return View();
        } 

        [Authorize]
        [HttpPost]
        public IActionResult Edit(CameraExtendedServiceModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cameraModel);
            }

            this.cameras.Add(
              cameraModel.Make,
              cameraModel.Model,
              cameraModel.Price,
              cameraModel.Quantity,
              cameraModel.MinShutterSpeed,
              cameraModel.MaxShutterSpeed,
              cameraModel.MinISO,
              cameraModel.MaxISO,
              cameraModel.IsFullFrame,
              cameraModel.VideoResolution,
              cameraModel.LightMeterings,
              cameraModel.Description,
              cameraModel.ImageURL,
              this.userManager.GetUserId(User)
              );

            return RedirectToAction(nameof(CamerasController.All));
        }

        [Authorize]
        public IActionResult Delete(string id) => View(id);

        [Authorize]
        public IActionResult DeleteFromDb(string id)
        {
            this.cameras.Delete(id);

            return RedirectToAction(nameof(CamerasController.All));
        }
    }
}