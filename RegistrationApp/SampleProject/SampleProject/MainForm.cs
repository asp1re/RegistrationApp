using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SampleProject
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

            LoadCourseData();

            

            //generate data
            subjectComboBx.Items.Add("Econ");
            subjectComboBx.Items.Add("Math");
            timesComboBx.Items.Add("7:00 am");
            timesComboBx.Items.Add("8:30 am");
            timesComboBx.Items.Add("10:00 am");
            daysComboBx.Items.Add("M, W, F");
            daysComboBx.Items.Add("T, Th");

            //load *data* from file here          

            foreach (Course c in courseList.Courses)
            {             
                courseListBox.Items.Add(String.Format("{0, -5} {1, -10} {2, -15} {3, -20}",c.Subject, c.CourseNumber, c.StartTime, c.Days));
                sCourseListBox.Items.Add(String.Format("{0, -5} {1, -10} {2, -15} {3, -20}", c.Subject, c.CourseNumber, c.StartTime, c.Days));
            }
        }

        //variables
        Student studentList = new Student();
        Course courseList = new Course();
        List<Course> preReqList = new List<Course>();
        List<Course> historyList = new List<Course>();


        

        

        private void gradStudChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (!gradStudChkBx.Checked)
            {
                studentGmatTbx.Visible = false;
                gmatLbl.Visible = false;
            }

            else
            {
                studentGmatTbx.Visible = true;
                gmatLbl.Visible = true;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void newStudentChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (newStudentChkBx.Checked)
            {
                newStudentMsgLbl.Visible = true;
                newStudentMsgLbl2.Visible = true;
                studentListLbl.Visible = false;
                studentListComboBx.Visible = false;
                //random ID number for new user
                studentIdTbx.Text = GenerateID();
            }
            else
            {
                studentListComboBx.Visible = true;
                studentListLbl.Visible = true;
                newStudentMsgLbl.Visible = false;
                newStudentMsgLbl2.Visible = false;
                ClearStudent();
            }
        }

        private void saveStudentBtn_Click(object sender, EventArgs e)
        {
            //add course history
            UpdateList(sCourseHistoryListBox, historyList);

            //create temporary student object for non-grad
            if (!gradStudChkBx.Checked)
            {
                Student s = new Student(studentIdTbx.Text, studentFNameTbx.Text, studentLNameTbx.Text, Convert.ToDecimal(studentGPATbx.Text), historyList);
                studentList.Students.Add(s); //add to list of students
                ClearStudent(); //clear form
            }
            //create temporary student object for grads
            else
            {
                Student g = new GradStudent(studentIdTbx.Text, studentFNameTbx.Text, studentLNameTbx.Text, Convert.ToDecimal(studentGPATbx.Text), Convert.ToInt32(studentGmatTbx.Text), historyList);
                studentList.Students.Add(g); //add to list of students
                ClearStudent(); //clear form
            }

            //update student list combo box
            studentListComboBx.Items.Clear();

            foreach(Student s in studentList.Students)
            {
                studentListComboBx.Items.Add(s.LastName + ", " + s.FirstName);
            }
            
            
        }

        private void saveCourseBtn_Click(object sender, EventArgs e)
        {
            if (prereqListBox.Items.Count == 0)
            {
                Course cNo = new Course(subjectComboBx.Text, numberTbx.Text, titleTbx.Text, unitsTbx.Text, timesComboBx.Text, daysComboBx.Text, seatsAvailTbx.Text);
                courseList.Courses.Add(cNo);
                ClearCourse();               
            }
            else
            {
                UpdateList(prereqListBox,preReqList);

                Course c = new Course(subjectComboBx.Text, numberTbx.Text, titleTbx.Text, unitsTbx.Text, timesComboBx.Text, daysComboBx.Text, seatsAvailTbx.Text, preReqList);
                courseList.Courses.Add(c);
                ClearCourse();
            }

            courseListBox.Items.Clear();
            sCourseListBox.Items.Clear();

            //repopulate list
            foreach(Course c in courseList.Courses)
            {      
                courseListBox.Items.Add(c.Subject + ", " + c.CourseNumber + ", " + c.StartTime + ", " + c.Days);
                sCourseListBox.Items.Add(c.Subject + ", " + c.CourseNumber + ", " + c.StartTime + ", " + c.Days);
            }
        }


        //methods
        public string GenerateID()
        {
            Random random = new Random();
            string r = "";
            for (int i = 1; i < 11; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return r;
        }

        private void prereqButton_Click(object sender, EventArgs e)
        {


            if (courseListBox.SelectedItem != null)
            {
                prereqListBox.Items.Add(courseListBox.SelectedItem);
                courseListBox.Items.Remove(courseListBox.SelectedItem);
                courseListBox.ClearSelected();
            }
            if (prereqListBox.Items.Count != 0 && prereqListBox.SelectedItem != null)
            {
                courseListBox.Items.Add(prereqListBox.SelectedItem);
                prereqListBox.Items.Remove(prereqListBox.SelectedItem);
                prereqListBox.ClearSelected();
            }
        }
        private void UpdateList(ListBox inListBox, List<Course> inList)
        {
            foreach (string s in inListBox.Items)
            {
                foreach (Course c in courseList.Courses)
                {
                    if (s.Contains(c.Subject) && s.Contains(c.CourseNumber))
                    {
                        inList.Add(c);
                    }
                }
            }
        }

        private void courseHistoryButton_Click(object sender, EventArgs e)
        {
            if (sCourseListBox.SelectedItem != null)
            {
                sCourseHistoryListBox.Items.Add(sCourseListBox.SelectedItem);
                sCourseListBox.Items.Remove(sCourseListBox.SelectedItem);              
            }
            if (sCourseHistoryListBox.Items.Count != 0 && sCourseHistoryListBox.SelectedItem != null)
            {
                sCourseListBox.Items.Add(sCourseHistoryListBox.SelectedItem);
                sCourseHistoryListBox.Items.Remove(sCourseHistoryListBox.SelectedItem);
                sCourseHistoryListBox.ClearSelected();
            }

        }

        //clear info after saving student
        public void ClearStudent()
        {
            newStudentChkBx.Checked = false;
            gradStudChkBx.Checked = false;
            studentIdTbx.Clear();
            studentFNameTbx.Clear();
            studentLNameTbx.Clear();
            studentGPATbx.Clear();
            sCourseHistoryListBox.Items.Clear();
        }
        //clear info after saving course
        public void ClearCourse()
        {
            subjectComboBx.Text = "";
            timesComboBx.Text = "";
            daysComboBx.Text = "";
            numberTbx.Clear();
            titleTbx.Clear();
            unitsTbx.Clear();
            seatsAvailTbx.Clear();
            prereqListBox.Items.Clear();
        }

        private void studentListComboBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(Student s in studentList.Students)
            {
                if (studentListComboBx.Text.Contains(s.FirstName) && studentListComboBx.Text.Contains(s.LastName))
                {
                    studentIdTbx.Text = s.StudentID;
                    studentFNameTbx.Text = s.FirstName;
                    studentLNameTbx.Text = s.LastName;
                    studentGPATbx.Text = Convert.ToString(s.GPA);
                    foreach(Course c in s.CourseHistory)
                    {
                        sCourseHistoryListBox.Items.Add(String.Format("{0, -5} {1, -10} {2, -15} {3, -20}", c.Subject, c.CourseNumber, c.StartTime, c.Days));
                    }                                      
                }
                
            }
        }
        public void LoadCourseData()
        {
            //csv file read
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\CourseData.csv");
            string[] courseSplit;
            string[] preReqSplit;
            List<string> courseLoop = new List<string>();

            //loop through file and store course data
            while (!sr.EndOfStream)
            {
                courseSplit = sr.ReadLine().Split(',');

                foreach (string s in courseSplit)
                {
                    courseLoop.Add(s);
                }
            }


            //add each course from data file to courseList
            for (int i = 0; i < courseLoop.Count; i+=8)
            {
                if(courseLoop[i+7] != "0")
                {
                    preReqSplit = courseLoop[i + 7].Split(':');

                    foreach(string s in preReqSplit)
                    {
                        foreach(Course p in courseList.Courses)
                        {
                            if (s == p.Subject + p.CourseNumber)
                            {
                                preReqList.Add(p);
                            }
                        }
                    }

                    Course c = new Course(courseLoop[i], courseLoop[i + 1], courseLoop[i + 2], courseLoop[i + 3], courseLoop[i + 4], courseLoop[i + 5], courseLoop[i + 6], preReqList);

                    courseList.Courses.Add(c);
                }
                else
                {
                    Course c = new Course(courseLoop[i], courseLoop[i + 1], courseLoop[i + 2], courseLoop[i + 3], courseLoop[i + 4], courseLoop[i + 5], courseLoop[i + 6]);

                    courseList.Courses.Add(c);
                }               
            }

            //close stream
            sr.Close();
        }
    }
    
}
