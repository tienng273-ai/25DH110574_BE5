using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE5_CustomerSite.Models
{
    [MetadataType(typeof(Metadata.UserMetadata))]
    public partial class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
