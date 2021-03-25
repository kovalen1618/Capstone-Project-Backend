using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Entities.Models
{
    [Table("playlist")]
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
