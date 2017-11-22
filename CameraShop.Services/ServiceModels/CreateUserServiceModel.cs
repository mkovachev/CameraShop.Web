namespace CameraShop.Services.ServiceModels
{
    public class CreateUserServiceModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
