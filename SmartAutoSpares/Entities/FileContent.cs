using System;

namespace SmartAutoSpares.Entities
{
    public partial class FileContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
