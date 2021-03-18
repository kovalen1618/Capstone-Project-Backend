using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Entities.Models
{
    public class QuoteItem : Item   // Extend the Item class
    {
        public string Text { get; set; }
        public string Font { get; set; }

    }
}
