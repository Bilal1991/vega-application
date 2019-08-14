using System.ComponentModel.DataAnnotations;

namespace vega_application.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(100)]
        public string name { get; set; }
        [Required]
        [StringLength(20)]
        public string phone { get; set; }
        [StringLength(100)]
        public string email { get; set; }
    }
}
