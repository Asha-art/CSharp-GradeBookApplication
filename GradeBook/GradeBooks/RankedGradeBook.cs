using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
            Students = new List<Student>();
        }

        public override char GetLetterGrade(double averageGrade)
        {   
            //3.

            if (Students.Count() < 5) 
            {
               throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }
            //calculate Number of students to drop a letter grade (20% of Number of students)

            var topGrade = (int)Math.Ceiling(0.2 * Students.Count()); // eg: 100 * 0.2 = 20 , so 21st- 40th student below average grade 90, will be grade B and so on...

            // put average grades in order ,
            var orderGrades = Students.OrderByDescending(student => student.AverageGrade).Select(student => student.AverageGrade).ToList();
            //var orderGrades = Students.OrderByDescending(student => student.AverageGrade);
            //foreach (var student in Students)
            //{
            //    var orderGrades = GetLetterGrade(student.AverageGrade);
            //}

                // figure out where input grade fit in which grade , every x student with higher grades than input grade knocks the letter grade down until F

                if (averageGrade >= orderGrades[topGrade-1])
                return 'A';
            else if (averageGrade >= orderGrades[(topGrade * 2) -1] )
                return 'B';
            else if (averageGrade >= orderGrades[(topGrade * 3) - 1])
                return 'C';
            else if (averageGrade >= orderGrades[(topGrade * 4) - 1])
                return 'D';
            else
                return 'F';

        }

        //4.
        public override void CalculateStatistics()
        {
            if (Students.Count() >= 5)
                base.CalculateStatistics();
            else
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
            return;                    

        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count() >= 5)
                base.CalculateStudentStatistics(name);
            else
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
            return;
        }

    }
}
