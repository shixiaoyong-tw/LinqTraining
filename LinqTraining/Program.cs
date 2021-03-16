using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTraining
{
    class Program
    {
        #region ready data

        private static readonly List<Student> Students = new List<Student>
        {
            new Student
            {
                Age = 23,
                City = "广州",
                Name = "小C",
                Scores = new List<int> {85, 88, 83, 97}
            },
            new Student
            {
                Age = 27,
                City = "广州",
                Name = "小D",
                Scores = new List<int> {84, 59, 67, 98}
            },
            new Student
            {
                Age = 18,
                City = "广西",
                Name = "小明",
                Scores = new List<int> {86, 78, 85, 90}
            },
            new Student
            {
                Age = 33,
                City = "梦里",
                Name = "小叁",
                Scores = new List<int> {86, 68, 73, 97}
            }
        };

        private static readonly List<Teacher> Teachers = new List<Teacher>
        {
            new Teacher
            {
                Age = 35,
                City = "梦里",
                Name = "啵哆"
            },
            new Teacher
            {
                Age = 28,
                City = "云南",
                Name = "小红"
            },
            new Teacher
            {
                Age = 38,
                City = "河南",
                Name = "丽丽"
            }
        };

        #endregion

        static void Main(string[] args)
        {
            #region GroupBy() 、group...by、group...by...into sample

            // GroupSample();

            #endregion

            #region GroupJoin() 、join...in...on...equals...into sample

            // GroupJoinSample();

            #endregion

            #region Join() 、join...in...on...equals sample

            //JoinSample();

            #endregion

            #region OrderBy() 、orderby sample

            //OrderBySample();

            #endregion

            #region OrderByDescending、orderby...descending sample

            //OrderByDescendingSample();

            #endregion

            #region Select()、select sample

            //SelectSample();

            #endregion

            #region SelectMany()、select sample

            //TODO:chris to do

            #endregion

            #region ThenBy()、orderby...,... sample

            //ThenBySample();

            #endregion

            #region ThenByDescending、orderby...,...descending sample

            //ThenByDescendingSample();

            #endregion

            #region Where()、where sample

            //WhereSample();

            #endregion

            #region Max() sample

            //MaxSample();

            #endregion

            #region Sum() sample

            //SumSample();

            #endregion

            #region FirstOrDefault() sample

            //FirstOrDefaultSample();

            #endregion

            #region Distinct() sample

            //DistinctSample();

            #endregion

            #region All() sample

            //AllSample();

            #endregion

            #region Any() sample

            //AnySample();

            #endregion

            Console.ReadLine();
        }

        /// <summary>
        /// GroupBy() 、group...by、group...by...into sample
        /// </summary>
        private static void GroupSample()
        {
            var result = Students.GroupBy(x => x.City);

            foreach (var @group in result)
            {
                Console.WriteLine(@group.Key);
                foreach (var student in @group)
                {
                    Console.Write($"{student.Name} ");
                }

                Console.WriteLine();
            }

            var resultOfGroupBy = from student in Students
                                  group student by student.City;

            foreach (var @group in resultOfGroupBy)
            {
                Console.WriteLine(@group.Key);
                foreach (var student in @group)
                {
                    Console.Write($"{student.Name} ");
                }

                Console.WriteLine();
            }

            var resultOfGroupByInto = from student in Students
                                      group student by student.City
                into studentGroup
                                      where studentGroup.Count() > 1
                                      select studentGroup;

            foreach (var @group in resultOfGroupByInto)
            {
                Console.WriteLine(@group.Key);
                foreach (var student in @group)
                {
                    Console.Write($"{student.Name} ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// GroupJoin() 、join...in...on...equals...into sample
        /// </summary>
        private static void GroupJoinSample()
        {
            //lookup student and teacher city is same
            var result = Students.GroupJoin(
                Teachers,
                student => student.City,
                teacher => teacher.City,
                (student, teachers) => new
                {
                    StudentName = student.Name,
                    Teachers = teachers
                });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.StudentName}\t");
                foreach (var teacher in item.Teachers)
                {
                    Console.Write($"{teacher.Name}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            var result1 = from student in Students
                          join teacher in Teachers on student.City equals teacher.City into teachers
                          select new { StudentName = student.Name, Teachers = teachers };

            foreach (var item in result1)
            {
                Console.WriteLine($"{item.StudentName}\t");
                foreach (var teacher in item.Teachers)
                {
                    Console.Write($"{teacher.Name}");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Join() 、join...in...on...equals sample
        /// </summary>
        private static void JoinSample()
        {
            var result = Students.Join(
                Teachers,
                student => student.City,
                teacher => teacher.City,
                (student, teacher) => new
                {
                    StudentName = student.Name,
                    TeacherName = teacher.Name
                });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.StudentName},{item.TeacherName}");
            }

            var result1 = from student in Students
                          join teacher in Teachers on student.City equals teacher.City
                          select new { StudentName = student.Name, TeacherName = teacher.Name };

            foreach (var item in result1)
            {
                Console.WriteLine($"{item.StudentName},{item.TeacherName}");
            }
        }

        /// <summary>
        /// OrderBy() 、orderby sample
        /// </summary>
        private static void OrderBySample()
        {
            var result = Students.OrderBy(student => student.Age);

            foreach (var item in result)
            {
                Console.Write($"{item.Age} ");
            }

            Console.WriteLine();

            var result1 = from student in Students
                          orderby student.Age
                          select student;

            foreach (var item in result1)
            {
                Console.Write($"{item.Age} ");
            }
        }

        /// <summary>
        /// OrderByDescending、orderby...descending sample
        /// </summary>
        private static void OrderByDescendingSample()
        {
            var result = Students.OrderByDescending(student => student.Age);

            foreach (var item in result)
            {
                Console.Write($"{item.Age} ");
            }

            Console.WriteLine();

            var result1 = from student in Students
                          orderby student.Age descending
                          select student;

            foreach (var item in result1)
            {
                Console.Write($"{item.Age} ");
            }
        }

        /// <summary>
        ///  Select()、select sample
        /// </summary>
        private static void SelectSample()
        {
            var result = Students.Select(student => new
            {
                Name = student.Name,
                Age = student.Age
            });

            foreach (var item in result)
            {
                Console.WriteLine($"student name is {item.Name},age is {item.Age}");
            }

            Console.WriteLine();

            var result1 = from student in Students
                          select new
                          {
                              Name = student.Name,
                              Age = student.Age
                          };

            foreach (var item in result1)
            {
                Console.WriteLine($"student name is {item.Name},age is {item.Age}");
            }
        }

        /// <summary>
        /// ThenBy()、orderby...,... sample
        /// </summary>
        private static void ThenBySample()
        {
            var result = Students
                .OrderBy(student => student.Age)
                .ThenBy(student => student.Scores.Max());

            foreach (var item in result)
            {
                Console.Write($"{item.Name} ");
            }

            Console.WriteLine();

            var result1 = from student in Students
                          orderby student.Age, student.Scores.Max()
                          select student;

            foreach (var item in result1)
            {
                Console.Write($"{item.Name} ");
            }
        }

        /// <summary>
        /// ThenByDescending、orderby...,...descending sample
        /// </summary>
        private static void ThenByDescendingSample()
        {
            var result = Students
                .OrderByDescending(student => student.Age)
                .ThenByDescending(student => student.Scores.Max());

            foreach (var item in result)
            {
                Console.Write($"{item.Name} ");
            }

            Console.WriteLine();

            var result1 = from student in Students
                          orderby student.Age descending, student.Scores.Max() descending
                          select student;

            foreach (var item in result1)
            {
                Console.Write($"{item.Name} ");
            }
        }

        /// <summary>
        /// Where()、where sample
        /// </summary>
        private static void WhereSample()
        {
            var result = Students.Where(student => student.Age > 20);

            foreach (var item in result)
            {
                Console.WriteLine($"student name is {item.Name}, age is {item.Age}");
            }

            Console.WriteLine();

            var result1 = from student in Students
                          where student.Age > 20
                          select student;

            foreach (var item in result1)
            {
                Console.WriteLine($"student name is {item.Name}, age is {item.Age}");
            }
        }

        /// <summary>
        /// Max() sample
        /// </summary>
        private static void MaxSample()
        {
            var result = Students.Max(student => student.Age);
            Console.WriteLine($"student max age is {result}");
        }

        /// <summary>
        /// Sum() sample
        /// </summary>
        private static void SumSample()
        {
            var result = Students.Sum(student => student.Age);
            Console.WriteLine($"student total age sum is {result}");
        }

        /// <summary>
        /// FirstOrDefault() sample
        /// </summary>
        private static void FirstOrDefaultSample()
        {
            var result = Students.FirstOrDefault(student => student.City.Equals("广州"));

            Console.WriteLine($"the student name is {result?.Name}, city is {result?.City}");
        }

        /// <summary>
        /// Distinct() sample
        /// </summary>
        private static void DistinctSample()
        {
            var numberArray = new int[] { 1, 2, 3, 4, 5, 6, 6, 7 };
            var result = numberArray.Distinct();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// All() sample
        /// </summary>
        private static void AllSample()
        {
            var isAllMoreThan18 = Students.All(student => student.Age > 17);

            if (isAllMoreThan18)
            {
                Console.WriteLine("all student age is more than 17");
            }
        }

        /// <summary>
        /// Any() sample
        /// </summary>
        private static void AnySample()
        {
            var isAllMoreThan18 = Students.Any(student => student.Age > 30);

            if (isAllMoreThan18)
            {
                Console.WriteLine("exist student age is more than 30");
            }
        }
    }
}