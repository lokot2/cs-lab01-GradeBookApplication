using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name,bool isWeighted) :base (name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            var prog = (int)Math.Ceiling(Students.Count * 0.2);
            var stopien = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (stopien[prog - 1] <= averageGrade)
                return 'A';
            else if (stopien[(prog * 2) - 1] <= averageGrade)
                return 'B';
            else if (stopien[(prog * 3) - 1] <= averageGrade)
                return 'C';
            else if (stopien[(prog * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';

            
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                    return;
            }

            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count<5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
