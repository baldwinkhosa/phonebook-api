using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace phonebook.Models
{
    [Table("Contact", Schema = "dbo")]
    public class Contact 
    {
        public Contact()
        {
            CreatedDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public string FirstName  { get; set;}
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public DateTime CreatedDate { get; private set; }

    }
}