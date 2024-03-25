using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Applicant.Domain.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property for the user who created the album
        public string UserId { get; set; }
        public virtual User User { get; set; }

        // Navigation property for photos within the album
        public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();
    }
}
