using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Entities.Models
{
    [Table("QuoteItem")]
    public class QuoteItem : Item   // Extend the Item class
    {
        public string Text { get; set; }
        public string Font { get; set; }

    }
}
