using System;

namespace SmartAutoSpares.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ExpoPushToken { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneNumberVerified { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOnline { get; set; }
        public string AvatarURL { get; set; }
        public int AverageRating { get; set; }
        public bool HasAvatar { get; set; }
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
