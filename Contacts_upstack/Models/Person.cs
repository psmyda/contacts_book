using System.ComponentModel.DataAnnotations.Schema;

namespace Contacts_upstack.Models
{
    [Table("tblPersons")]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
