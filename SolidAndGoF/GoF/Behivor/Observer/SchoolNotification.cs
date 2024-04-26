using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidAndGoF.GoF.Behivor.Observer
{
    public class SchoolNotification
    {
        public class EvaluateSubjectEventHandler : EventArgs
        {
            public string StudenName { get; set; }
            public string Subject { get; set; }
            public double Score { get; set; }
        }

        public class Teacher
        {
            public string Subject { get; set; }
            public Teacher(string courseName)
            {
                Subject = courseName;
            }

            public event EventHandler<EvaluateSubjectEventHandler> Updates;

            public void Evaluate( string studenName, double score)
            {
                Updates?.Invoke(this, new EvaluateSubjectEventHandler { Subject = Subject, Score = score, StudenName = studenName });
            }

        }

        public class Student
        {
       
            public static void TeacherNotification(object sender, EvaluateSubjectEventHandler e)
            {
               Console.WriteLine($"The score for '{e.StudenName}' in the {e.Subject} subject was {e.Score}");
            }
        }
    }
}
