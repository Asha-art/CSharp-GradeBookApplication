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
            

        }

       
        public override void CalculateStatistics()
        {
           
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
            return;                    

        }

        public override void CalculateStudentStatistics(string name)
        {
           
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
            return;
        }

    }
}
