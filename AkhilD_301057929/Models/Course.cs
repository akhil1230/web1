using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkhilD_301057929.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]


        public string courseName { get; set; }
        [Key]
        public int courseCode { get; set; }
        public string courseDepartment { get; set; }
        public string coursePre { get; set; }
        public ICollection<AssignFaculty> assignFaculties { get; set; }
    }
}
