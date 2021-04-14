using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Entities.DataTransferObjects
{
    public class ItemDto
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public string Type { get; set; }
        public ItemDataDto Data { get; set; }
    }
}
