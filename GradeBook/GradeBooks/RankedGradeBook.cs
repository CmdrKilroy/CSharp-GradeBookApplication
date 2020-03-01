﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                throw new InvalidOperationException();
            }

            var cutoff = (int)Math.Truncate(Students.Count * 0.2);

            var averageGrades =
                (from student in Students
                orderby student.AverageGrade descending
                select student.AverageGrade).ToList();

            var classPosition = averageGrades.IndexOf(averageGrade);
            
            if (classPosition < cutoff)
            {
                return 'A';
            }
            else
            {
                classPosition -= cutoff;
                if (classPosition < cutoff)
                {
                    return 'B';
                }
                else
                {
                    classPosition -= cutoff;
                    if (classPosition < cutoff)
                    {
                        return 'C';
                    }
                    else
                    {
                        classPosition -= cutoff;
                        if (classPosition < cutoff)
                        {
                            return 'D';
                        }
                    }
                }
            }

            return 'F';
        }
    }
}
