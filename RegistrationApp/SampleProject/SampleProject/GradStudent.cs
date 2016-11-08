using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject
{
    class GradStudent : Student
    {
        //variables
        private int gmatScore;

        //properties
        public int GMATScore
        {
            get
            {
                return gmatScore;
            }
            set
            {
                gmatScore = value;
            }
        }

        //constructor
        public GradStudent(string inStudentID, string inFirst, string inLast, decimal inGPA, int inGMAT, List<Course> inCourseHistory) : base (inStudentID, inFirst, inLast, inGPA, inCourseHistory)
        {
            GMATScore = inGMAT;
            StudentID = inStudentID;
            FirstName = inFirst;
            LastName = inLast;
            GPA = inGPA;
            CourseHistory = inCourseHistory;
        }
    }
}
