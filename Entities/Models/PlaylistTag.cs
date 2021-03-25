using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Entities.Models
{
    public class PlaylistTag
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
    }
}
