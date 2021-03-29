using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Entities.DataTransferObjects
{
    public class TagForUpdateDto
    {
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Tag must be between 1 " +
            "and 20 characters")]
        public string Name { get; set; }
    }
}
