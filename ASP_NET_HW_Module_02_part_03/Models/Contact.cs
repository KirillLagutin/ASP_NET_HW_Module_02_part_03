using System.ComponentModel.DataAnnotations;

namespace ASP_NET_HW_Module_02_part_03.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Phone]
        [Display(Name = "Phone")]
        public string Tel { get; set; }

        [Phone]
        [Display(Name = "Alternative phone")]
        public string AltTel { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Description { get; set; }
    }
}
