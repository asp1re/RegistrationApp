using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject
{
    class Course
    {
        //Variables, Properties
        private List<Course> courses = new List<Course>();
        private List<Course> prerequisites = new List<Course>();
        private string subject;
        private string courseNumber;
        private string courseTitle;
        private string units;
        private string startTime;
        private string days;
        private string seats;      

        //Accessors -- Get, Set
        public List<Course> Courses
        {
            get
            {
                return courses;
            }
            set
            {
                courses = value;
            }
        }
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }
        public string CourseNumber
        {
            get
            {
                return courseNumber;
            }
            set
            {
                courseNumber = value;
            }
        }
        public string CourseTitle
        {
            get
            {
                return courseTitle;
            }
            set
            {
                courseTitle = value;
            }
        }
        public string Units
        {
            get
            {
                return units;
            }
            set
            {
                units = value;
            }
        }
        public string StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }
        public string Days
        {
            get
            {
                return days;
            }
            set
            {
                days = value;
            }
        }
        public string Seats
        {
            get
            {
                return seats;
            }
            set
            {
               seats = value;
            }
        }
        public List<Course> Prerequisites
        {
            get
            {
                return prerequisites;
            }
            set
            {
                prerequisites = value;
            }
        }

        // Default Constructor Method
        public Course()
        {

        } // end of Student Constructor Method

        //constructor without prerequisites
        public Course(string inSubject, string inCourseNumber, string inCourseTitle, string inCourseUnits, string inStartTime, string inDays, string inSeats)
        {
            Subject = inSubject;
            CourseNumber = inCourseNumber;
            CourseTitle = inCourseTitle;
            Units = inCourseUnits;
            StartTime = inStartTime;
            Days = inDays;
            Seats = inSeats;
        }

        //constructor for course with prerequisites
        public Course(string inSubject, string inCourseNumber, string inCourseTitle, string inCourseUnits, string inStartTime, string inDays, string inSeats, List<Course> inPreqs)
        {
            Subject = inSubject;
            CourseNumber = inCourseNumber;
            CourseTitle = inCourseTitle;
            Units = inCourseUnits;
            StartTime = inStartTime;
            Days = inDays;
            Seats = inSeats;
            Prerequisites = inPreqs;
        }
    }
}
