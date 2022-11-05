using System;
using System.Collections.Generic;

namespace SmartAutoSpares.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
