using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkhilD_301057929.Models;

namespace AkhilD_301057929.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Faculty.
            if (context.Faculties.Any())
            {
                return;   // DB has been seeded
            }

            var faculties = new Faculty[]
            {
            new Faculty{firstName="Carson",lastName="Alexander", facultyId=1 },
            new Faculty{firstName="Meredith",lastName="Alonso", facultyId=2},
            new Faculty{firstName="Arturo",lastName="Anand", facultyId=3},
            new Faculty{firstName="Gytis",lastName="Barzdukas", facultyId=4},
            new Faculty{firstName="Yan",lastName="Li", facultyId=5},
            new Faculty{firstName="Peggy",lastName="Justice", facultyId=6},
            new Faculty{firstName="Laura",lastName="Norman", facultyId=7},
            new Faculty{firstName="Nino",lastName="Olivetto", facultyId=8}
            };
            foreach (Faculty f in faculties )
            {
                context.Faculties.Add(f);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{ coursePre="1050", courseName="Chemistry", courseCode=01},
            new Course{coursePre="4022",courseName="Microeconomics", courseCode=02},
            new Course{coursePre="4041",courseName="Macroeconomics", courseCode=03},
            new Course{coursePre="1045",courseName="Calculus", courseCode=04},
            new Course{coursePre="3141",courseName="Trigonometry", courseCode=05},
            new Course{coursePre="2021",courseName="Composition",courseCode=06},
            new Course{coursePre="2042",courseName="Literature", courseCode=07}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var assignFaculty = new AssignFaculty[]
            {
            new AssignFaculty{ facultyId=1, courseCode=02,classId=001 },
            new AssignFaculty{ facultyId=2, courseCode=04, classId=002},
            new AssignFaculty{ facultyId=3, courseCode=06, classId=003},
            new AssignFaculty{ facultyId=4, courseCode=07, classId=004}
           
            
            };
            foreach (AssignFaculty e in assignFaculty)
            {
                context.AssignFaculties.Add(e);
            }
            context.SaveChanges();
        }
    }
}
