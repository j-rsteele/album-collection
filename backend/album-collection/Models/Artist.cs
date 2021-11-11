using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace album_collection.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string imageUrl { get; set; }
        public int Age { get; set; }
        public string recordLabel { get; set; }
        public string Hometown { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}
