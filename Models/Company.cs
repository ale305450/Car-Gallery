using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Learing_Core.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Company Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        public byte[] CompanyLogo { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
