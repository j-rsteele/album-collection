using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace album_collection.Models
{
    public class Album
    {
        public int ID { get; set; }

        public string title { get; set; }

        //public string imageID

        public string artist { get; set; }

        public string review { get; set; }

        public virtual List<Song> songs { get; set; }
    }
}

album
id
title
image
artist
songs (either as a string to be separated, or see below)
reviews
record label

song
id
title
album