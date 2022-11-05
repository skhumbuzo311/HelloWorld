using System.Collections.Generic;

namespace SmartAutoSpares.Models
{
    public class SignupResponse
    {
        public List<string> AdminsExpoPushTokens { get; set; }
        public User User { get; set; }
    }
}
