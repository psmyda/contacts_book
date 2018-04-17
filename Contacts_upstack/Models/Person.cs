using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts_upstack.Models
{
    [Table("tblPersons")]
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name="Phone number")]
        public string Phone { get; set; }
    }
}
