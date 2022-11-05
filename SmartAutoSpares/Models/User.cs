using System;

namespace SmartAutoSpares.Models
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
        public bool IsAHSAdmin { get; set; }
        public bool IsTutor { get; set; }
        public bool IsPasswordEncrypted { get; set; }
        public string AvatarURL { get; set; }
        public bool HasAvatar { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string ConnectionId { get; set; }
    }
}
