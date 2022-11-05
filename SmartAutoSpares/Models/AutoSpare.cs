using System;
using System.Collections.Generic;

namespace SmartAutoSpares.Models
{
    public class AutoSpare
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Number { get; set; }
        public string YearModel { get; set; }
        public int Price { get; set; }

        public List<string> imagesUrls { get; set; }
        public IEnumerable<Entities.AutoSpareLike> Likes { get; set; }
    }
}