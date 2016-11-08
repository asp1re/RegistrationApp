using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject
{
    class Student
    {
        // Variables, Properties
        private List<Student> students = new List<Student>();
        private string studentID;
        private string firstName;
        private string lastName;
        private decimal gpa;
        private List<Course> courseHistory = new List<Course>();


        // Accessors -- Get/Set
        public List<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                value = students;
            }
        }
        public List<Course> CourseHistory
        {
            get
            {
                return courseHistory;
            }
            set
            {
                courseHistory = value;
            }
        }
        public string StudentID
        {
            get
            {
                return studentID;
            }
            set
            {
                studentID = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public decimal GPA
        {
            get
            {
                return gpa;
            }
            set
            {
                gpa = value;
            }
        }


        // Default Constructor Method
        public Student()
        {

        } // end of Student Constructor Method


        public Student(string inStudentID, string inFirst, string inLast, decimal inGPA, List<Course> inCourseHistory)
        {
            studentID = inStudentID;
            FirstName = inFirst;
            LastName = inLast;
            GPA = inGPA;
            CourseHistory = inCourseHistory;
        }
    }
}
