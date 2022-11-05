using System;
namespace SmartAutoSpares.Entities
{
    public partial class Configuration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
