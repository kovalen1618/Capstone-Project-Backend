using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Entities.Models
{
    [Table("tag")]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlaylistTag> PlaylistTags { get; set; }
    }
}
