using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkhilD_301057929.Models
{
    public class AssignFaculty
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int classId { get; set; }
        public int facultyId { get; set; }
        public int courseCode { get; set; }
       

        public Faculty Faculty { get; set; }
        public Course Course { get; set; }

    }
}
