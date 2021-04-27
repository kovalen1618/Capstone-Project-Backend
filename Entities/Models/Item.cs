using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Entities.Models
{
   
    public class Item
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public int ItemDataId { get; set; } 
        public string ItemDataType { get; set; }
    }
}
