using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Entities.DataTransferObjects
{
    public class ItemDataDto
    {
    }
    public class QuoteItemDataDto : ItemDataDto
    { 
        public string Text { get; set; }
        public string Font { get; set;  }
    }

}
