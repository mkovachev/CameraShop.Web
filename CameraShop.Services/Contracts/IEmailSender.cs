﻿using System.Threading.Tasks;

namespace CameraShop.Services.Contracts
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
