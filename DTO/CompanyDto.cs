using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learing_Core.DTO
{
    public class CompanyDto
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Company Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }
        public byte[] CompanyLogo { get; set; }
    }
}
