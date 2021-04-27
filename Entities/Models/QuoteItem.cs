using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Entities.Models
{
    [Table("quoteItem")]
    public class QuoteItem   // Extend the Item class
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Font { get; set; }
        public Item Item  { get; set; }

    }
}
