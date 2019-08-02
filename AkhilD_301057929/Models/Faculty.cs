using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkhilD_301057929.Models
{
    public class Faculty
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int facultyId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string department { get; set; }
         public string email { get; set; }
         public int ext { get; set; }
        public ICollection<AssignFaculty> assignFaculties { get; set; }
    }
}
