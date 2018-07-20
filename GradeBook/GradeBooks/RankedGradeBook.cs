using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
            }

            List<double> rankedAverageGrade = new List<double>();

            foreach (var student in Students)
            {
                rankedAverageGrade.Add(student.AverageGrade);
            }

            rankedAverageGrade.Sort();

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);

            if (rankedAverageGrade[threshold * 4] <= averageGrade)
                return 'A';
            else if (rankedAverageGrade[threshold * 3] <= averageGrade)
                return 'B';
            else if (rankedAverageGrade[threshold * 2] <= averageGrade)
                return 'C';
            else if (rankedAverageGrade[threshold] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

    }
}
