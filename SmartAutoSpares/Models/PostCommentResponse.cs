using SmartAutoSpares.Entities;
using System.Collections.Generic;

namespace SmartAutoSpares.Models
{
    public class PostCommentResponse
    {
        public PostComment Comment { get; set; }
        public List<string> ExpoTokens { get; set; }
    }
}
